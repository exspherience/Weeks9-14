using UnityEngine;
using UnityEngine.Events;

public class ProximityHazard : MonoBehaviour
{
    public SpriteRenderer playerRenderer;
    public GameObject obstacle;
    public PlayerController player;
    public UnityEvent onTouch;

    public bool isCarrot;
    public bool currentlyOnObject = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(playerRenderer.bounds.Contains(transform.position) && !currentlyOnObject)
        {
            onTouch.Invoke();
            currentlyOnObject = true;

            if(isCarrot)
            {
                obstacle.SetActive(false);
            }
        }
        else if(!playerRenderer.bounds.Contains(transform.position) && currentlyOnObject)
        {
            currentlyOnObject = false;
        }
    }
}
