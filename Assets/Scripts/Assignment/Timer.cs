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
        StartTimer();
        winText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = timer.ToString("#.00");
    }

    public void StartTimer()
    {
        timerCoroutine = StartCoroutine(RunTimer());
    }

    public void EndTimer()
    {
        if(timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
        }

        winText.text = ("You Win!\nFinal Time: " + timer.ToString("#.00"));
        winText.enabled = true;
    }

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
