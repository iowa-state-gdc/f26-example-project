using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    // Error for floating point
    const float EPSILON = (float)1e-6;

    // The percentage of the board to move per second
    [SerializeField]
    private float moveSpeed = 1.0f;

    // Our current movement direction
    public int HVel { get; private set; } = 0;

    // Our current horizontal position as a percentage
    private float hPos = 0.5f;

    // Called when a paddle input is detected
    public void OnPaddle(InputAction.CallbackContext context)
    {
        // Read the input value
        float axis = context.ReadValue<float>();

        // Store the move direction
        HVel = (axis < EPSILON && axis > -EPSILON) ? 0 : (int)Mathf.Sign(axis);
    }

    // The update/tick function
    private void Update()
    {
        // If we are moving left
        if (HVel < 0)
        {
            // Move left, clamping within the board bounds
            hPos = Mathf.Max(hPos + HVel * moveSpeed * Time.deltaTime, 0.0f);
        }
        // If we are moving right
        else if (HVel > 0)
        {
            // Move right, clamping within the board bounds
            hPos = Mathf.Min(hPos + HVel * moveSpeed * Time.deltaTime, 1.0f);
        }

        // Update the horizontal position of the paddle
        transform.position = new Vector3(7.0f * (hPos - 0.5f), transform.position.y, transform.position.z);
    }
}
