using UnityEngine;

public class GrowTree : MonoBehaviour
{
    public float treeGrowDuration;
    private float treeGrowProgress = 0f;

    public float appleGrowDuration;
    private float appleGrowProgress = 0f;

    bool onGrowPressed = false;
    bool onTreeGrown = false;

    public Transform appleTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.localScale = Vector3.zero;
        appleTransform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (onGrowPressed)
        {
            treeGrowProgress += Time.deltaTime;
            transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, treeGrowProgress / treeGrowDuration);

            if(treeGrowProgress > treeGrowDuration)
            {
                onTreeGrown = true;
            }
        }

        if(onTreeGrown)
        {
            appleGrowProgress += Time.deltaTime;
            appleTransform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, appleGrowProgress / appleGrowDuration);
        }
    }

    public void OnGrow()
    {
        onGrowPressed = true;
    }
}
