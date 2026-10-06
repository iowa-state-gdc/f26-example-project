using UnityEngine;

public class Brick : MonoBehaviour
{
    // A reference to the renderer for the brick
    private SpriteRenderer renderer;

    // Set the color of the brick
    public void setColor(Color c)
    {
        renderer.color = c;
    }

    // Called when this object is created
    private void Awake()
    {
        // Find the reference to this object's renderer
        renderer = GetComponent<SpriteRenderer>();
    }
}
