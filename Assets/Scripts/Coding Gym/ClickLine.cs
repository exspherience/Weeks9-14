
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickLine : MonoBehaviour
{
    // Draw a line from the player to the mouse position (using the Input System). When the
    // mouse is clicked(use the PlayerInput componentÅfs UI Click UnityEvent), use a coroutine to move the player game
    // object towards the mouse position, updating the line as it moves.
    //
    // Store mouse clicks in a list of positions, extending the line to each new click.When the player arrives at the
    // position, remove it from the list(and from the line) If there are still points in the list, start the
    // movement coroutine again so the player moves to every position in the list.
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
