using UnityEngine;

public class SawMoving : MonoBehaviour
{
    public float rotationSpeed = 180f;
    public float moveSpeed     = 2f;
    public float moveDistance  = 3f;

    private Vector3 startPos;
    private float direction = 1f;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);

        transform.position += Vector3.right * direction * moveSpeed * Time.deltaTime;

        if (Mathf.Abs(transform.position.x - startPos.x) >= moveDistance)
            direction *= -1f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            other.GetComponent<BallController>().Respawn();
    }
}