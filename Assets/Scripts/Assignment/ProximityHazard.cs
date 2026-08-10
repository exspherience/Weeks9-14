using UnityEngine;
using UnityEngine.Events;

public class ProximityHazard : MonoBehaviour
{
    public SpriteRenderer playerRenderer;
    public GameObject carrot;
    public PlayerController player;
    public UnityEvent onTouch;

    public bool isCarrot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(playerRenderer.bounds.Contains(transform.position))
        {
            onTouch.Invoke();

            if(isCarrot)
            {
                carrot.SetActive(false);
            }
        }
    }
}
