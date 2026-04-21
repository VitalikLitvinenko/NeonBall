using UnityEngine;

public class EndZone : MonoBehaviour
{
    public GameObject victoryScreen;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.ShowVictory();
            victoryScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}