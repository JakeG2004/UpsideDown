using UnityEngine;

public class IdleBounce : MonoBehaviour
{
    public float bounceHeight = 0.2f; // How high it bounces
    public float bounceSpeed = 2f;   // How fast it bounces

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.localPosition;
    }

    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
        transform.localPosition = new Vector3(startPosition.x, newY, startPosition.z);
    }
} 
