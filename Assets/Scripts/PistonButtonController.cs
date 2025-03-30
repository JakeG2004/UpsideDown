using UnityEngine;

public class PistonButtonController : MonoBehaviour
{
    private PistonController Piston;    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Piston = GameObject.FindGameObjectWithTag("Piston").GetComponent<PistonController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

	public void OnTriggerEnter2D(Collider2D obj)
	{
//		if(obj.tag == "Player")
//		{
			Piston.activate();
//      }
	}
}
