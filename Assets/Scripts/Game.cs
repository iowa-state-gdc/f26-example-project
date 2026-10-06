using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField]
    private GameObject brickPrefab;

	// Create all of our bricks
	private void initBricks()
	{
		for (int x = -5; x < 5; x++)
		{
			for (int y = 0; y < 10; y++)
			{
				// Create a new brick
				GameObject brick = Instantiate(brickPrefab, transform);

				// Position the brick
				brick.transform.position = new Vector3(0.75f * x + 0.375f, -0.5f * y + 3.75f, 0.0f);

				// Set the color of the brick based on its relative position
				brick.GetComponent<Brick>().setColor(new Color(1.0f - 0.1f * y, 0.1f * y, 0.2f + 0.1f * (x & 1)));
			}
		}
	}

    // Called when this object is created
    private void Start()
	{
        initBricks();
    }

    // Called when the reset input is detected
    public void OnReset(InputAction.CallbackContext context)
	{
		// Reload the scene
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}