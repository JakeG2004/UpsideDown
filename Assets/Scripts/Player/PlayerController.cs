using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _sr;

    [SerializeField] private KeyCode _left = KeyCode.A;
    [SerializeField] private KeyCode _right = KeyCode.D;
    [SerializeField] private KeyCode _jump = KeyCode.W;

    [SerializeField] private float _acceleration = 1.5f;
    [SerializeField] private float _topSpeed = 5f;
    [SerializeField] private float _drag = 0.25f;
    [SerializeField] private float _jumpForce = 5.0f;
    [SerializeField] private Transform _raycastPos;
    [SerializeField] private float _groundCheckDist = 0.1f;

    private bool _isGrounded = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    	// Get references to components
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();

        if(!_rb)
        {
            Debug.LogWarning("Failed to get rigidbody!");
        }
    }

    // Update is called once per frame
    void Update()
    {
    	// Only update if the player isn't dying
        if(!_animator.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
        	GroundCheck();
        	DoPlayerMovement();
    	}
    	else
    	{
    		_rb.linearVelocityX = 0;
    	}
    }

    public void FlipGravity()
    {
        _rb.gravityScale *= -1;
        transform.Rotate(180, 0, 0);
    }

    void GroundCheck()
    {
        // Send a raycast downward
        RaycastHit2D hit = Physics2D.Raycast(_raycastPos.position, -Vector2.up);
        
        // If it hits, determine whether the point is close enough to be grounded
        if(hit)
        {
            float dist = Mathf.Abs(hit.point.y - _raycastPos.position.y);

            // set if close enough
            if(dist < _groundCheckDist)
            {
                _isGrounded = true;
                return;
            }

            // otherwise, dont set
            _isGrounded = false;
            return;
        }

        _isGrounded = false;
    }

    void DoPlayerMovement()
    {
    	// Stop running animation
        if(Input.GetKeyUp(_right))
        {
        	_animator.Play("Idle");
        }
        else if(Input.GetKeyUp(_left))
        {
        	_animator.Play("Idle");
        }
        
        // Get horizontal movement
        if(Input.GetKey(_right))
        {
        	_sr.flipX = false;
            
            _rb.linearVelocityX += _acceleration;
            
            // If player isn't jumping, play run animation
            if(!_animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
            {
            	_animator.Play("Run");
        	}
        }

        else if(Input.GetKey(_left))
        {
        	_sr.flipX = true;
            
            _rb.linearVelocityX -= _acceleration;
            if(!_animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
            {
            	_animator.Play("Run");
        	}
        }

        // Drag
        else if(Mathf.Abs(_rb.linearVelocityX) != 0.0f)
        {
            // Stop moving when slow enough
            if(Mathf.Abs(_rb.linearVelocityX) <= 0.2f)
            {
                _rb.linearVelocityX = 0.0f;
            }

            // Apply the drag
            else
            {
                _rb.linearVelocityX -= Mathf.Sign(_rb.linearVelocityX) * _drag;
            }
        }

        // Cap the speed
        if(Mathf.Abs(_rb.linearVelocityX) > _topSpeed)
        {
            _rb.linearVelocityX = Mathf.Sign(_rb.linearVelocityX) * _topSpeed;
        }

        // Jumping
        if(Input.GetKeyDown(_jump) && _isGrounded)
        {
            // Second frame of the animation calls jump()
            _animator.Play("Jump");
        }
    }
    
    // Called by the second frame of the "Jump" animation
    public void jump()
    {
    	_rb.linearVelocityY = _jumpForce * Mathf.Sign(_rb.gravityScale);
    }
    
    // Called by the last frame of the "Die" animation
    private void die()
    {
    	Destroy(gameObject);
    	SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    // Collision
    void OnCollisionEnter2D(Collision2D coll)
    {
    	if( (coll.gameObject.tag == "BlueKiller" && tag == "Player1")
    	 || (coll.gameObject.tag == "GreenKiller" && tag == "Player2") )
    	{
    		_animator.Play("Die");
    	}
    }
}
