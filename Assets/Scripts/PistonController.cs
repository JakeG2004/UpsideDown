using UnityEngine;

public class PistonController : MonoBehaviour
{
	// Characteristics
	private float speed = 10f;
	private float power = 10f;
	
	private Vector3 start;
	private Vector3 end;
	private bool movingUp = true;
	private bool moving = false;
	private float moveDist = 0f;
	private float maxMoveDist = 0.8f;
	
	// Player
	private GameObject Player;
	
	// Called when initialized
	public void Start()
	{	
		start = transform.position;
		end = start + transform.up * maxMoveDist;
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
		GetComponent<AudioSource>().Play();
		moving = true;
	}
	
	// Moves the piston
    private void move()
    {
    	// Move up and stop when it hits the top
    	if(movingUp && moveDist < maxMoveDist)
    	{
    		transform.position += transform.up * speed * Time.deltaTime;
    		moveDist += speed * Time.deltaTime;
    	}
    	else if(movingUp && moveDist >= maxMoveDist)
    	{
    		movingUp = false;
    		moveDist = 0;
    		transform.position = end;
    	}
    	// Move down and stop when hitting the bottom
    	else if(!movingUp && moveDist < maxMoveDist)
    	{
    		transform.position -= transform.up * speed * Time.deltaTime;
    		moveDist += speed * Time.deltaTime;
    	}
    	else if(!movingUp && moveDist >= maxMoveDist)
    	{
    		movingUp = true;
    		moving = false;
    		moveDist = 0;
    		transform.position = start;
    	}
    	else
    	{
    		Debug.Log("ERROR: No possible movement");
    	}
    }
    
    // Push player
    public void OnTriggerStay2D(Collider2D obj)
    {
		if(moving && movingUp && (obj.tag == "Player1" || obj.tag == "Player2"))
		{
    		Rigidbody2D playerRb = obj.GetComponent<Rigidbody2D>();
    		playerRb.linearVelocityY = power * Mathf.Sign(playerRb.gravityScale);
/*    		playerRb.linearVelocity = transform.up * power * Mathf.Sign(playerRb.gravityScale);
    		Debug.Log(playerRb.linearVelocityX);
    		playerRb.linearVelocityX *= 5;
    		Debug.Log(playerRb.linearVelocityX);
*/    	}
    }
}
