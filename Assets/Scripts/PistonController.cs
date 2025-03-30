using UnityEngine;

public class PistonController : MonoBehaviour
{
	// Characteristics
	private float speed = 10f;
	private float power = 10f;
	
	private float startY;
	private float endY;
	private bool movingUp = true;
	private bool moving = false;
	
	// Player
	private GameObject Player;
	
	// Called when initialized
	public void Start()
	{	
		startY = transform.position.y;
		endY = startY + 1;
	}
	
	// Called every frame
	public void Update()
	{
		if(moving)
		{
			move();
		}
	}
	
	// Initiate piston movement
	public void activate()
	{
		moving = true;
	}
	
	// Moves the piston
    private void move()
    {
    	// Move up and stop when it hits the top
    	if(movingUp && transform.position.y <= endY)
    	{
    		transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
    	}
    	else if(movingUp && transform.position.y > endY)
    	{
    		movingUp = false;
    		transform.position = new Vector3(transform.position.x, endY, 0);
    	}
    	// Move down and stop when hitting the bottom
    	else if(!movingUp && transform.position.y >= startY)
    	{
    		transform.position -= new Vector3(0, 1, 0) * speed * Time.deltaTime;
    	}
    	else if(!movingUp && transform.position.y < startY)
    	{
    		movingUp = true;
    		moving = false;
    		transform.position = new Vector3(transform.position.x, startY, 0);
    	}
    	else
    	{
    		Debug.Log("ERROR: No possible movement");
    	}
    }
    
    // Push player
    public void OnTriggerEnter2D(Collider2D obj)
    {
//    	if(obj.tag == "Player")
//		{
    		Rigidbody2D playerRb = obj.GetComponent<Rigidbody2D>();
    		playerRb.linearVelocityY = power;
//    	}
    }
}
