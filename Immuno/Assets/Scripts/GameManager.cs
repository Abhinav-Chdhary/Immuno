using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ParticleSystem playerExplosion;
    public ParticleSystem asteroidExplosion;
    public Player player;
    public int lives = 3;
    public int score = 0;
    public float respawnTime = 3.0f;

    public void AsteroidDestroyed(Asteroid asteroid)
    {
        score++;
        asteroidExplosion.transform.position = asteroid.transform.position;
        asteroidExplosion.Play();
    }
    public void PlayerDied()
    {
        playerExplosion.transform.position = player.transform.position;
        playerExplosion.Play();

        lives--;
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
        //something
    }
}
