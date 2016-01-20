using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int health;
	private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () 
	{
		rb2d = this.gameObject.GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		
		rb2d.velocity = new Vector2(1.0f,0.0f);



		DeathCheck();
	}


	private void DeathCheck()
	{

		if(health <= 0)
		{
			Destroy(this.gameObject);
		}
	}

}
