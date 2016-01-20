using UnityEngine;
using System.Collections;

public class CameraCheck : MonoBehaviour {

	public bool withinCamView = false;

	private Vector3 objectPos;
	private Camera cam;

	// Use this for initialization
	void Start () 
	{
		cam = Camera.main;
		objectPos = cam.WorldToScreenPoint(this.gameObject.transform.position);

		CheckActive();

	}
	
	// Update is called once per frame
	void Update () 
	{



	
	}

	void CheckActive()
	{
		if(objectPos.x >= 0.0f && objectPos.x <= cam.pixelWidth && objectPos.y >= 0.0f && objectPos.y <= cam.pixelHeight)
		{
			withinCamView = true;
			this.gameObject.active = true;
			print("ACTIVE");
		}
		else
		{
			withinCamView = false;
			this.gameObject.active = false;
			print("OFF");
		}
	}
}
