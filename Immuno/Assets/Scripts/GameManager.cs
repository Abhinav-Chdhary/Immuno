using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ParticleSystem playerExplosion;
    public ParticleSystem asteroidExplosion;
    public Player player;
    public Text _immunity;
    public Text _lives;
    public GameObject _gameOverText;
    public int lives = 3;
    public int score = 0;
    public float respawnTime = 3.0f;
    private AudioSource _explosionSound;

    private void Awake()
    {
        _explosionSound = GetComponent<AudioSource>();
        _lives.text = lives.ToString();
        _immunity.text = score.ToString();
        _gameOverText.gameObject.SetActive(false);
    }
    private void Update()
    {
        if(lives<=0 && Input.GetKeyDown(KeyCode.Return))
        {
            NewGame();
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    private void NewGame()
    {
        lives = 3;
        score = 0;
        _lives.text = lives.ToString();
        _immunity.text = score.ToString();

        _gameOverText.SetActive(false);
        Invoke(nameof(Respawn), respawnTime);
    }
    public void AsteroidDestroyed(Asteroid asteroid)
    {
        asteroidExplosion.transform.position = asteroid.transform.position;
        asteroidExplosion.Play();
        _explosionSound.Play();

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
        _gameOverText.SetActive(true);
    }
}
