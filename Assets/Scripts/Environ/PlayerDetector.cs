using UnityEngine;
using UnityEngine.Events;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] public UnityEvent _p1Event;
    [SerializeField] private UnityEvent _p2Event;
    [SerializeField] private UnityEvent _anyPlayerEvent;

    [SerializeField] private bool _oneShot = false;
    private bool _activated = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(_oneShot && _activated)
        {
            return;
        }

        if(other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")
        {
            _activated = true;
            _anyPlayerEvent.Invoke();
        }

        if(other.gameObject.tag == "Player1")
        {
            _activated = true;
            _p1Event.Invoke();
            return;
        }

        if(other.gameObject.tag == "Player2")
        {
            _activated = true;
            _p2Event.Invoke();
        }
    }
}
