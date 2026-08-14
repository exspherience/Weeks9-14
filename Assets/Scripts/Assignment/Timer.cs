using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI winText;
    Coroutine timerCoroutine;
    public bool isRacing = true;
    float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // begins timer and disables win text
        StartTimer();
        winText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // updates timer text, only shows 2 decimal points
        timerText.text = timer.ToString("#.00");
    }

    // begins coroutine for timer
    public void StartTimer()
    {
        timerCoroutine = StartCoroutine(RunTimer());
    }

    // ends timer and displays win message
    public void EndTimer()
    {
        if(timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
        }

        winText.text = ("You Win!\nFinal Time: " + timer.ToString("#.00"));
        winText.enabled = true;
        isRacing = false;
    }

    // coroutine for timer
    IEnumerator RunTimer()
    {
        timer = 0;

        while(isRacing)
        {
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
