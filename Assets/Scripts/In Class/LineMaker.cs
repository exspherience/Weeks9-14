using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class LineMaker : MonoBehaviour
{
    public float growDuration;
    LineRenderer lineRenderer;
    Coroutine growCoroutine;
    public Vector3 startPosition;
    public Vector3 endPosition;
    bool growing = false; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        if (lineRenderer == null)
        {
            Debug.Log("LineMaker does not have a LineRenderer component.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        // grow line from left to right over amount of time
        if (context.performed) //&& !growing)
        {
            // needs to be here or ese key release will cancel coroutine
            if (growCoroutine != null)
            {
                StopCoroutine(growCoroutine);
            }

            growCoroutine = StartCoroutine(GrowUpdate());
            //growing = true;
        }       
    }

    IEnumerator GrowUpdate()
    {
        float t = 0;
        // decreases line so position only has 2
        // currently set up with 4
        lineRenderer.positionCount = 2;

        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, startPosition);

        while (t < growDuration)
        {
            Vector2 currentSecondPosition = Vector2.Lerp(startPosition, endPosition, t / growDuration);
            lineRenderer.SetPosition(1, currentSecondPosition);
            t += Time.deltaTime;
            yield return null;
        }
        //growing = false;
    }
}
