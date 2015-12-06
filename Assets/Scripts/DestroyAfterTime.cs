using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {

	public float aliveTime;
	private float timer = 0.0f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if(timer >= aliveTime)
		{
			Destroy(this.gameObject);
		}
		else
		{
			timer += Time.deltaTime;
		}
	}
}
