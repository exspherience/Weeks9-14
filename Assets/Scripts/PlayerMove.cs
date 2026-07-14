using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    private Vector2 movementDirection = Vector2.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // cast Vector2 to Vector3 so it can be assigned to position
        transform.position += (Vector3)movementDirection * speed * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // CallbackContext
        // Value passed to UnityEvent
        // data structure which stores information on input
        // Input System records and uses
        // This will automatically read controller or keyboard input
        movementDirection = context.ReadValue<Vector2>();
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        // phase represents what type of action being provided 
        if(context.performed) // checks if in performed phase
        {
            Debug.Log("Attack! " + context.phase);
        }
    }
}
