using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public Transform playerObject;
	public Transform objectManager;
	private Vector3 playerPos;

	private float cameraWidth;
	private float cameraHeight;
	public float max_cam_move_time;


	private Camera cam;
	private string camera_direction = "NONE";
	private bool cameraTransitioning = false;

	private float camera_move_time;
	private Vector3 new_cam_pos;
	// Use this for initialization
	void Start () 
	{
		cam = Camera.main;

		cameraHeight = 2f * cam.orthographicSize;
		cameraWidth = cameraHeight * cam.aspect;

		new_cam_pos = cam.transform.position;

		print("CAM HEIGHT : " + cam.pixelHeight);
		print("CAM WIDTH : " + cam.pixelWidth);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//print("Player X Pos " + playerObject.transform.position.x);
		//print("Player Y Pos " + playerObject.transform.position.y);


		playerPos = cam.WorldToScreenPoint(playerObject.position);

		//print(cam.WorldToScreenPoint(playerObject.position));

		if(!cameraTransitioning)
		{
			
		
			if(playerPos.x >= cam.pixelWidth)
			{
				print("RIGHT");
				camera_direction = "RIGHT";
				new_cam_pos.x = cam.transform.position.x + cameraWidth;
				StartCoroutine("MoveCamera");
			}

			if(playerPos.x <= 0.0f)
			{
				print("LEFT");

				camera_direction = "LEFT";
				new_cam_pos.x = cam.transform.position.x - cameraWidth;
				StartCoroutine("MoveCamera");
			}


			if(playerPos.y >= cam.pixelHeight)
			{
				print("UP");

				camera_direction = "UP";
				new_cam_pos.y = cam.transform.position.y + cameraHeight;
				StartCoroutine("MoveCamera");
			}

			if(playerPos.y <= 0.0f)
			{
				print("DOWN");

				camera_direction = "DOWN";
				new_cam_pos.y = cam.transform.position.y - cameraHeight;
				StartCoroutine("MoveCamera");
			}

		}

	}


	IEnumerator MoveCamera()
	{
		float t = 0;
		Vector3 start = cam.transform.position;

		while(t < 1)
		{
			Time.timeScale = 0.0f;
			cam.transform.position = Vector3.Lerp(start, new_cam_pos, t);
			t += Time.unscaledDeltaTime/max_cam_move_time;
			yield return null;
		}

		ActivateObjectsWithinView();

		Time.timeScale = 1.0f;
		new_cam_pos = cam.transform.position;
	}

	void ActivateObjectsWithinView()
	{
		//GameObject[] camObjs = new Gameobject[GameObject.FindObjectsOfTypeAll<CameraCheck>()];
		cameraTransitioning = true;
		//THIS ACTIVATES THINGS THAT ARE UNDER OBJECT MANAGER AND IF THEY'RE IN CAMERA VIEW

		foreach(var thing in objectManager.GetComponentsInChildren<CameraCheck>(true)) 
		{
			print(thing.gameObject.name);
			Vector3 objectPos = Camera.main.WorldToScreenPoint(thing.gameObject.transform.position);

			if(objectPos.x >= 0.0f && objectPos.x <= Camera.main.pixelWidth && objectPos.y >= 0.0f && objectPos.y <= Camera.main.pixelHeight)
			{


				thing.gameObject.active = true;
				//print(thing.gameObject.name);
			}
			else
			{
				thing.gameObject.active = false;
			}
		}

		cameraTransitioning = false;
	}
}
