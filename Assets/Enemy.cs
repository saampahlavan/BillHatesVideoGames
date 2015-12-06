using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int health;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{


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
