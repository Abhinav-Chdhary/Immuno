using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ParticleSystem playerExplosion;
    public ParticleSystem asteroidExplosion;
    public Player player;
    public Text _immunity;
    public Text _lives;
    public int lives = 3;
    public int score = 0;
    public float respawnTime = 3.0f;

    public void AsteroidDestroyed(Asteroid asteroid)
    {
        asteroidExplosion.transform.position = asteroid.transform.position;
        asteroidExplosion.Play();

        if (asteroid.size < 0.75)
            score += 100;
        else if (asteroid.size < 1.25)
            score += 50;
        else
            score += 25;
        _immunity.text = score.ToString();
    }
    public void PlayerDied()
    {
        playerExplosion.transform.position = player.transform.position;
        playerExplosion.Play();

        lives--; _lives.text = lives.ToString();
        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            Invoke(nameof(Respawn), respawnTime);
        }
    }
    private void Respawn()
    {
        player.transform.position= Vector3.zero;
        player.gameObject.layer = LayerMask.NameToLayer("IgnoreCollisions");
        player.gameObject.SetActive(true);
        Invoke(nameof(TurnOnCollisions), 3.0f);
    }
    private void TurnOnCollisions()
    {
        player.gameObject.layer = LayerMask.NameToLayer("Player");
    }
    private void GameOver()
    {
        lives = 0;
        score = 0;

        Invoke(nameof(Respawn), respawnTime);
    }
}
