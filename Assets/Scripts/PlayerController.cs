using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public bool canMove = true;

	public float movement_threshold;
	public float movement_threshold2;


	public Vector2 speed;

    public bool canUseWeapon = true;
	// Use this for initialization

	private Rigidbody2D rb2d;
	private float horizontal_input;
	private float vertical_input;

	public string facingDirection;
	private Animator anim;
	private bool isRunning;



	void Start () 
	{
		facingDirection = "RIGHT";
		rb2d = this.gameObject.GetComponent<Rigidbody2D>();
		rb2d.freezeRotation = true;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{

		// 0 = Up
		// 1 = Right
		// 2 = Down
		//3 = Left

		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");

		
		//CONTROLS

		if(horizontal >= movement_threshold || horizontal <= -movement_threshold)
		{
			speed.x = 1.0f * Mathf.Sign(horizontal);
			isRunning = true;

            if(canMove)
            {

           
			    if(speed.x > 0.0)
			    {
				    facingDirection = "RIGHT";
			    }
			    else if(speed.x < 0.0)
			    {
				    facingDirection =  "LEFT";
			    }
            }


        }


		if(horizontal < movement_threshold2 && horizontal > -movement_threshold2)
		{
			speed.x = 0.0f;

	
		}

		if(vertical >= movement_threshold || vertical <= -movement_threshold)
		{
			speed.y = 1.0f * Mathf.Sign(vertical);
			isRunning = true;

            if (canMove)
            {


                if (speed.y > 0)
                {
                    facingDirection = "UP";
                }
                else if (speed.y < 0)
                {
                    facingDirection = "DOWN";
                }
            }

		}

		///DIRECTION OUTPUT
		//print ("DIRECTION OF BILL: " + facingDirection);

		if(vertical < movement_threshold2 && vertical > -movement_threshold2)
		{
			speed.y = 0.0f;

		}


			

		// run anim
		if(speed.x != 0.0f || speed.y != 0.0f)
		{
			isRunning = true;
		}
		else
		{
			isRunning = false;
		}

		if(canMove)
		{
			rb2d.velocity = speed;
		}
		else
		{
			rb2d.velocity = new Vector2(0.0f,0.0f);
			isRunning = false;
		}
		//if(speed.x == 0.0f && speed.y == 0.0f)
			//isRunning = false;


		//direction and facing.

		anim.SetFloat("speedX", speed.x);
		anim.SetFloat("speedY", speed.y);
		anim.SetBool("isRunning", isRunning);

		if(isRunning)
		{
			anim.SetFloat("idleX", speed.x);
			anim.SetFloat("idleY", speed.y);
		}


		//anim.SetFloat("speedX", Mathf.Abs(speed.x));
		//anim.SetFloat("speedY", speed.y);

		if(facingDirection == "RIGHT")
		{
			transform.localScale = new Vector3(1.0f,1.0f,1.0f);
			//anim.SetInteger("Direction", 1);
		}
		else if(facingDirection == "LEFT")
		{
			transform.localScale = new Vector3(-1.0f,1.0f,1.0f);
			//anim.SetInteger("Direction", 4);
		}

	}
}
