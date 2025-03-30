using UnityEngine;

public class GravityGate : MonoBehaviour
{
    private enum GateType
    {
        P1,
        P2,
        All
    }

    [SerializeField] GateType _gateType;

    void OnTriggerEnter2D(Collider2D other)
    {
        if((other.gameObject.tag == "Player1" && _gateType == GateType.P1) || (other.gameObject.tag == "Player2" && _gateType == GateType.P2))
        {
            other.GetComponent<PlayerController>().FlipGravity();
        }
    }
}
