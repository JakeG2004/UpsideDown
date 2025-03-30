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
        if ((other.CompareTag("Player1") && _gateType == GateType.P1) || (other.CompareTag("Player2") && _gateType == GateType.P2) || _gateType == GateType.All)
        {
            other.GetComponent<PlayerController>().FlipGravity();
        }
        else if ((other.CompareTag("Player1") && _gateType == GateType.P2) || (other.CompareTag("Player2") && _gateType == GateType.P1))
        {
            Rigidbody2D otherRB = other.GetComponent<Rigidbody2D>();
            otherRB.linearVelocityX *= -1.1f;
            
            Transform otherTransform = other.transform;
            otherTransform.position += new Vector3(Mathf.Sign(otherRB.linearVelocityX) * 0.1f, 0, 0);
        }
    }
}
