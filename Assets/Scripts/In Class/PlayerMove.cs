using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    private Vector2 movementDirection = Vector2.zero;
    private Vector3 lookAngle = Vector3.zero;
    private Vector3 barrelAngle = Vector3.zero;

    public Vector2 directionToMouse = Vector3.zero;
    Vector2 mousePosition = Vector3.zero;
    public Transform barrel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // cast Vector2 to Vector3 so it can be assigned to position
        transform.position += (Vector3)movementDirection * speed * Time.deltaTime;
        
        // looking
        transform.eulerAngles += lookAngle * rotationSpeed * Time.deltaTime;
        // barrel movement
        //barrel.up = barrelAngle * speed * Time.deltaTime;
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

    public void OnLook(InputAction.CallbackContext context)
    {
        // rotation go wheeeeeeeeeeee
        lookAngle.z = context.ReadValue<Vector2>().x;
        
        // turret logic
        //barrelAngle = context.ReadValue<Vector2>();     
    }
}
