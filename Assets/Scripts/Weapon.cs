using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	// Use this for initialization
	public string InputButton;
	public Transform weaponPrefab;

	private string spawnDirection;
	public Transform rightDirection;
	public Transform leftDirection;
	public Transform upDirection;
	public Transform downDirection;

    public bool usingWeapon = false;
    private float usingWeaponTime;
	private float weaponTimer = 0.0f;

	private PlayerController controller;
    private bool weaponStopsPlayer;

	void Start () 
	{
		controller = this.gameObject.GetComponent<PlayerController>();
        weaponStopsPlayer = weaponPrefab.GetComponent<Direction>().stopsPlayerMovement;
        usingWeaponTime = weaponPrefab.GetComponent<Direction>().coolDownTime;
    }
	
	// Update is called once per frame
	void Update () 
	{
		spawnDirection = controller.facingDirection;
		

		if(usingWeapon == false && controller.canUseWeapon)
		{

		
			if((Input.GetButtonDown(InputButton)))
			{
				usingWeapon = true;
                controller.canUseWeapon = false;

				GameObject weaponSwing = (GameObject)Instantiate(weaponPrefab.gameObject, rightDirection.transform.position, Quaternion.identity);
				weaponSwing.transform.parent = this.gameObject.transform;

				weaponSwing.GetComponent<Direction>().direction = spawnDirection;
                weaponSwing.GetComponent<Direction>().input_button = InputButton;

                if (spawnDirection == "RIGHT")
				{
					weaponSwing.transform.position = rightDirection.transform.position;

				}
				else if(spawnDirection == "LEFT")
				{
					weaponSwing.transform.position = leftDirection.transform.position;
				}
				else if(spawnDirection == "DOWN")
				{
					weaponSwing.transform.position = downDirection.transform.position;
				}
				else if(spawnDirection == "UP")
				{
					weaponSwing.transform.position = upDirection.transform.position;
				}

			}





		}

       
		if(usingWeapon)
		{
			if(weaponTimer >= usingWeaponTime)
			{
				usingWeapon = false;
                controller.canUseWeapon = true;
				weaponTimer = 0.0f;
                if (weaponStopsPlayer)
                    controller.canMove = true;
			}
			else
			{
				weaponTimer += Time.deltaTime;
				usingWeapon = true;
                if (weaponStopsPlayer)
                    controller.canMove = false;
            }
		}

        //controller.canMove = !usingWeapon;

    }
}
