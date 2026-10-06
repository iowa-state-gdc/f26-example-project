using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    // A reference to the player's paddle
    [SerializeField]
    private Paddle paddleRef;

    // A reference to the physics body for the ball
    private Rigidbody2D rb;

    // The speed of the ball, in world units per second
    [SerializeField]
    private float moveSpeed = 4.0f;

    // A flag for whether or not the ball has been thrown
    private bool thrown = false;

    // Called when the throw input is detected
    public void OnThrow(InputAction.CallbackContext context)
    {
        // Mark the ball as thrown
        thrown = true;

        // Move the ball upwards
        rb.linearVelocityY = moveSpeed;
    }

    // The update/tick function
    private void Update()
    {
        // If the ball has not been thrown
        if (!thrown)
        {
            // Make the ball follow the paddle
            transform.position = new Vector3(paddleRef.transform.position.x, transform.position.y, transform.position.z);
        }
        // If the ball has been thrown and reaches the bottom of the board
        else if (transform.position.y < -3.875)
        {
            // Reload the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // When the ball hits something
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If it hits the paddle
        if (collision.gameObject.CompareTag("Paddle"))
        {
            // Slightly influence the balls velocity based on how the paddle is moving
            rb.linearVelocity = rb.linearVelocity.normalized + new Vector2(collision.gameObject.GetComponent<Paddle>().HVel, 0).normalized / 2;
        }
        // If it hits a brick
        else if (collision.gameObject.CompareTag("Brick"))
        {
            // Destroy it!
            Destroy(collision.gameObject);
        }

        // Clamp our speed to the set move speed
        rb.linearVelocity = rb.linearVelocity.normalized * moveSpeed;
    }

    // Called when this object is created
    private void Start()
    {
        // Find the physics body for the ball
        rb = GetComponent<Rigidbody2D>();
    }
}
