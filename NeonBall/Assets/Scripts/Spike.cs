using UnityEngine;

public class Spike : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            BallController ball = other.GetComponent<BallController>();
            if (ball != null)
                ball.Respawn();
        }
    }
}