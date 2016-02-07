using UnityEngine;
using System.Collections;

public class TalkCollider : MonoBehaviour {

	// Use this for initialization

	private string facingDirection = "RIGHT";
	private PlayerController player_controls;

	public Transform right_Pos;
	public Transform left_Pos;
	public Transform up_Pos;
	public Transform down_Pos;

	void Start () 
	{
		player_controls = transform.parent.GetComponent<PlayerController>();

		facingDirection = player_controls.facingDirection;
	}
	
	// Update is called once per frame
	void Update () 
	{
		facingDirection = player_controls.facingDirection;

		if(facingDirection == "RIGHT")
		{
			this.gameObject.transform.position = right_Pos.transform.position;
		}
		else if(facingDirection == "LEFT")
		{
			this.gameObject.transform.position = left_Pos.transform.position;
		}
		else if(facingDirection == "DOWN")
		{
			this.gameObject.transform.position = down_Pos.transform.position;
		}
		else if(facingDirection == "UP")
		{
			this.gameObject.transform.position = up_Pos.transform.position;
		}
	}
}
