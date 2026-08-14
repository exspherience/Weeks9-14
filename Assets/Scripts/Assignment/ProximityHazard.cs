using UnityEngine;
using UnityEngine.Events;

public class ProximityHazard : MonoBehaviour
{
    public SpriteRenderer playerRenderer;
    public GameObject obstacle;
    public PlayerController player;
    public UnityEvent onTouch;

    public bool isCarrot;
    public bool isFinishLine;

    public bool currentlyOnObject = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // checks if player is within carrot or hurdle
        // invokes event and disables object
        if(playerRenderer.bounds.Contains(transform.position) && !currentlyOnObject && !isFinishLine)
        {
            onTouch.Invoke();
            currentlyOnObject = true;
            obstacle.SetActive(false);
        }
        // check if player is near finish line before invoking event
        else if(Vector2.Distance(transform.position, playerRenderer.transform.position) < 1f && isFinishLine)
        {
            onTouch.Invoke();
        }
        // player is not on object if outside of object bounds
        else if (!playerRenderer.bounds.Contains(transform.position) && currentlyOnObject)
        {
            currentlyOnObject = false;
        }
    }
}
