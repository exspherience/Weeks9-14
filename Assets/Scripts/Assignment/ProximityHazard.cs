using UnityEditor.ShaderGraph.Internal;
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
        if(playerRenderer.bounds.Contains(transform.position) && !currentlyOnObject && !isFinishLine)
        {
            onTouch.Invoke();
            currentlyOnObject = true;
            obstacle.SetActive(false);
        }
        else if(Vector2.Distance(transform.position, playerRenderer.transform.position) < 1f && isFinishLine)
        {
            onTouch.Invoke();
        }
        else if (!playerRenderer.bounds.Contains(transform.position) && currentlyOnObject)
        {
            currentlyOnObject = false;
        }
    }
}
