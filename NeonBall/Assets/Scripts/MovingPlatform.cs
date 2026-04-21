using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveSpeed    = 2f;
    public float moveDistance = 3f;

    private Vector3 startPos;
    private float direction = 1f;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.position += Vector3.right * direction * moveSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, startPos) >= moveDistance)
            direction *= -1f;
    }
}