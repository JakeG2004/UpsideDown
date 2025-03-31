using UnityEngine;

public class PistonButtonController : MonoBehaviour
{
    public PistonController Piston;
    
    private float pushTimer = 0f;
    private float pushTime = 1.3f;
    private float pushDistance = 0.08f;
    private bool pushed = false;
    
	private AudioSource _as;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		_as = GetComponent<AudioSource>();
//        Piston = GameObject.FindGameObjectWithTag("Piston").GetComponent<PistonController>();
    }

    // Update is called once per frame
    void Update()
    {
		if(pushed)
		{
			pushTimer += Time.deltaTime;
			
			if(pushTimer >= pushTime)
			{
				pushed = false;
				pushTimer = 0f;
				transform.position += transform.up * pushDistance; //new Vector3(0, pushDistance, 0);
			}
		}
    }

	public void OnTriggerEnter2D(Collider2D obj)
	{
		Debug.Log("Button collision");
		if(!pushed && (obj.tag == "Player1" || obj.tag == "Player2"))
		{
			_as.Play();
			transform.position -= transform.up * pushDistance;
			pushed = true;
			Piston.activate();
		}
	}
}
