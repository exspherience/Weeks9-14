using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineGrow : MonoBehaviour
{
    //public Transform appleTransform;
    public List<Transform> appleTransforms;
    Vector3 randomScale;
    Coroutine growCoroutine;
    Coroutine appleGrowCoroutine;

    public float treeGrowDuration;
    public float appleGrowDuration;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // to start coroutine
        // store in variable to be able to stop 
        growCoroutine = StartCoroutine(Grow());
        //randomScale = new Vector3(Random.Range(1, 3), Random.Range(1, 3), Random.Range(1, 3));
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    private IEnumerator Grow()
    {
        // coroutine runs thing in sequence (ex. tree grows first, then apple)
        float t = 0;

        while(t < treeGrowDuration)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.one * t / treeGrowDuration;

            // let everything else for one frame
            yield return null; // tells unity it can run multiple processes instead of freezing

            
        }
        // let everything else run for x seconds
        // example use: grow tree, wait for second before growing apples
        yield return new WaitForSeconds(1f);
        
        //grows apples simultaneously
        /*    t = 0;
        while (t < 1)
        { 
            //int i = 0;
            t += Time.deltaTime;
            for (int i = 0; i < appleTransforms.Count; i++)
            {
                appleTransforms[i].localScale = Vector3.one * t;


            }*/

        // grow one at time
        for (int i = 0; i < appleTransforms.Count; i++)
        {
            // by yield returning coroutine, will wait for it to finish before beginning next sequence
            yield return appleGrowCoroutine = StartCoroutine(AppleGrow(appleTransforms[i]));
        }
    }

    IEnumerator AppleGrow(Transform appleTransform)
    {
        float t = 0;
        while (t < appleGrowDuration)
        {
            //int i = 0;
            t += Time.deltaTime;
            appleTransform.localScale = Vector3.one * t / appleGrowDuration;//randomScale * t;

            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
    }    

    public void StopGrowing()
    {
        // always check if Coroutine is not null before stopping!
        if(growCoroutine != null) StopCoroutine(growCoroutine);
        if (appleGrowCoroutine != null) StopCoroutine(appleGrowCoroutine);
    }
}
