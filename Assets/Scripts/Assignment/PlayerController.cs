using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float defaultSpeed = 5;
    public float boostedSpeed = 2;
    public float rotationSpeed;
    private Vector2 movementDirection = Vector2.zero;
    private Vector3 spinRotation = Vector3.zero;

    public float minY = -7;
    public float maxY = 7;

    public float speedBoostDuration = 3;
    public float spinOutDuration = 3;

    public bool spinningOut = false;

    Coroutine boostCoroutine;
    Coroutine spinOutCoroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!spinningOut)
        {
            // calculate position using transform position with direction from input and speed
            Vector3 playerPos = transform.position + (Vector3)movementDirection * speed * Time.deltaTime;
            // clamp y on position so player cannot go out of bounds
            playerPos.y = Mathf.Clamp(playerPos.y, minY, maxY);
            // apply new position to transform position
            transform.position = playerPos;

            if (spinOutCoroutine != null)
            {
                StopCoroutine(spinOutCoroutine);
            }
        }

        transform.eulerAngles = spinRotation;
    }

    // get movement direction from player input
    public void OnMove(InputAction.CallbackContext context)
    {
        movementDirection = context.ReadValue<Vector2>();
    }

    //////////////////////
    /// Carrot Methods ///
    //////////////////////

    // start coroutine and increase speed
    public void SpeedUp()
    {
        speed += boostedSpeed;
        boostCoroutine = StartCoroutine(SpeedBoost());
    }

    // coroutine to keep speed for as long as duration is set to
    IEnumerator SpeedBoost()
    {
        float t = 0;
        while (t < speedBoostDuration)
        {
            t += Time.deltaTime;

            yield return null;
        }

        // reset speed after duration exceeded
        if (t >= speedBoostDuration)
        {
            speed = defaultSpeed;
        }
    }

    //////////////////////
    /// Hurdle Methods ///
    //////////////////////
    public void StopMovement()
    {
        spinOutCoroutine = StartCoroutine(SpinOut());
    }

    // coroutine to keep speed for as long as duration is set to
    IEnumerator SpinOut()
    {
        spinningOut = true;

        float t = 0;
        while (t < spinOutDuration)
        {
            t += Time.deltaTime;
            speed = 0;
            spinRotation.z += rotationSpeed;
            yield return null;
        }

        // reset speed after duration exceeded
        if (t >= spinOutDuration)
        {
            speed = defaultSpeed;
            spinRotation.z = 0;
            spinningOut = false;
        }

    }
}
