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
        Invoke(nameof(Respawn), respawnTime);
    }
    private void Respawn()
    {
        player.gameObject.SetActive(true);
    }
}