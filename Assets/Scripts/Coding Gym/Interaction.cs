using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    public int index = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sprite = spriteArray[index];
    }

    public void ChangeSprite(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            index++;

            if (index == spriteArray.Length)
            {
                index = 0;
            }
        }
    }
}
