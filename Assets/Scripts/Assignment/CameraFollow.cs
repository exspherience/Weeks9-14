using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform horse;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(FollowHorse());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // camera corotuine
    // follows horse throughout whole game
    IEnumerator FollowHorse()
    {
        while (true)
        {
            yield return null;

            Vector3 horsePos = horse.position;

            Vector3 cameraPos = new Vector3(horsePos.x, horsePos.y, transform.position.z);

            transform.position = cameraPos;
        }
    }
}
