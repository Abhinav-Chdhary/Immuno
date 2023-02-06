using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public int lives = 3;
    public int score = 0;
    public float respawnTime = 3.0f;

    public void PlayerDied()
    {
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
        player.gameObject.SetActive(true);
    }
    private void GameOver()
    {
        //something
    }
}
