using UnityEngine;
using System.Collections;

public class Direction : MonoBehaviour {

	public string direction;
    public string input_button;
    public bool stopsPlayerMovement = false;
    public float coolDownTime;

	private Animator anim;
	// Use this for initialization
	void Start () 
	{
		anim = this.gameObject.GetComponent<Animator>();

        

        setDirection();
    }
	
	// Update is called once per frame
	void Update () 
	{
        setDirection();

		
	}

    private void setDirection()
    {
        direction = transform.parent.GetComponent<PlayerController>().facingDirection;

        if (direction == "UP")
        {
            anim.SetInteger("direction", 0);
            transform.position = transform.parent.GetComponent<Weapon>().upDirection.position;
        }
        else if (direction == "RIGHT")
        {
            anim.SetInteger("direction", 1);
            transform.position = transform.parent.GetComponent<Weapon>().rightDirection.position;
        }
        else if (direction == "DOWN")
        {
            anim.SetInteger("direction", 2);
            transform.position = transform.parent.GetComponent<Weapon>().downDirection.position;
        }
        else if (direction == "LEFT")
        {
            anim.SetInteger("direction", 3);
            transform.position = transform.parent.GetComponent<Weapon>().leftDirection.position;
        }
    }
}
