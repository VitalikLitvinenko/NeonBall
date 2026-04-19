using UnityEngine;

public class BallController : MonoBehaviour
{
    public float moveSpeed     = 7f;
    public float jumpForce     = 10f;
    public float maxSpeed      = 12f;
    public float rotationSpeed = 200f;
    public float deceleration  = 10f;
    public Transform spawnPoint;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        float input = Input.GetAxis("Horizontal");

        if (input != 0)
        {
            rb.AddForce(Vector2.right * input * moveSpeed);

            if (Mathf.Abs(rb.linearVelocity.x) > maxSpeed)
                rb.linearVelocity = new Vector2(Mathf.Sign(rb.linearVelocity.x) * maxSpeed, rb.linearVelocity.y);
        }
        else if (isGrounded)
        {
            float newX = Mathf.Lerp(rb.linearVelocity.x, 0f, deceleration * Time.fixedDeltaTime);
            rb.linearVelocity = new Vector2(newX, rb.linearVelocity.y);
        }

        if (Mathf.Abs(rb.linearVelocity.x) > 0.1f)
        {
            float direction = Mathf.Sign(rb.linearVelocity.x);
            rb.angularVelocity = -direction * rotationSpeed;
        }
        else
        {
            rb.angularVelocity = 0f;
        }
    }

    public void Respawn()
    {
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        transform.position = spawnPoint != null ? spawnPoint.position : Vector3.zero;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        foreach (ContactPoint2D contact in col.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                isGrounded = true;
                break;
            }
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        isGrounded = false;
    }
}