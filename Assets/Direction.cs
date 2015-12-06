using UnityEngine;
using System.Collections;

public class Direction : MonoBehaviour {

	public string direction;

	private Animator anim;
	// Use this for initialization
	void Start () 
	{
		anim = this.gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(direction == "UP")
		{
			anim.SetInteger("direction", 0); 
		}
		else if(direction == "RIGHT")
		{
			anim.SetInteger("direction", 1); 
		}
		else if(direction == "DOWN")
		{
			anim.SetInteger("direction", 2); 
		}
		else if(direction == "LEFT")
		{
			anim.SetInteger("direction", 3); 
		}
	}
}
