using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyPlayer : MonoBehaviour {

    protected Joystick joystick;
    protected JumpButton jumpButton;

   
    protected bool jumping=false;
    protected bool isAlive=true;

    //config
    [SerializeField] public float runningSpped = 5f;
    [SerializeField] public float jumppingSpeed = 5f;
    

    //Cached component reference
    Rigidbody2D myrigidbody2D;
    Animator myanimator;
    CapsuleCollider2D myBodyCollider2D;
    BoxCollider2D myFeetCollider2D;
    Vector2 StartPosition;

	// Use this for initialization
	void Start () {
        joystick = FindObjectOfType<Joystick>();
        jumpButton = FindObjectOfType<JumpButton>();

        myrigidbody2D = GetComponent<Rigidbody2D>();
        myanimator = GetComponent<Animator>();
        myBodyCollider2D = GetComponent<CapsuleCollider2D>();
        myFeetCollider2D = GetComponent<BoxCollider2D>();
        StartPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        Run();
        FlipSprite();
        Jump();
      
	}


    public void Run()
    {
        
        myrigidbody2D.velocity = new Vector2(joystick.Horizontal * runningSpped+Input.GetAxis("Horizontal")*10f, myrigidbody2D.velocity.y);
        bool playerHorizontalSpeed = Mathf.Abs(myrigidbody2D.velocity.x) > Mathf.Epsilon;
        if (playerHorizontalSpeed)
        {
            myanimator.SetBool("Running", true);
        }
        else
        {
            myanimator.SetBool("Running", false);
        }
    }
    public void Jump()
    {
        if (!myFeetCollider2D.IsTouchingLayers(LayerMask.GetMask("Foreground")))
        {
            return;
        }  
        if (!jumping&& jumpButton.IsPressed)
        {
            jumping = true;
            myrigidbody2D.velocity = new Vector2(0f,jumppingSpeed);
            myanimator.SetBool("Jumpping", jumping);
        }
        if(jumping&& !jumpButton.IsPressed)
        {
            jumping = false;
            myanimator.SetBool("Jumpping", jumping);
        }
    }
    public void FlipSprite()
    {
        //if the player is moving horozintaly
        bool playerHorizontalSpeed = Mathf.Abs(myrigidbody2D.velocity.x) > Mathf.Epsilon;
        if (playerHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myrigidbody2D.velocity.x), 1f);

        }
    }
    public void Hurt()
    {
        if (myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            isAlive = false;
            myanimator.SetBool("Hurted", true);

            FindObjectOfType<Health>().LoseLife();
            myanimator.SetBool("Hurted", false);
        }
        
    }
    public void setLifeState(bool state)
    {
        isAlive = state;
    }
    public void ReSpawn()
    {
        myrigidbody2D.transform.position =StartPosition;
       
        myanimator.SetBool("Hurted", true);
        FindObjectOfType<Health>().LoseLife();
        myanimator.SetBool("Hurted", false);
    }
    

    
}
