using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public float duration = 5f; // Timer duration in seconds
    public UnityEvent onTimerComplete;

    private float timer;
    private bool isRunning = false;

    void Start()
    {
        StartTimer();
    }

    public void StartTimer()
    {
        timer = duration;
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    void Update()
    {
        if (isRunning)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                isRunning = false;
                onTimerComplete?.Invoke();
                StartTimer();
            }
        }
    }
}
