using UnityEngine;
using System.Collections;

public class Bow : MonoBehaviour {


    public Transform arrow_spawn_point;
    public GameObject arrow_prefab;

    public string input_button;

    public float arrowForce;

    private string direction;
    private float arrowRotation;

    private GameObject arrow;
	// Use this for initialization

	void Start ()
    {
        input_button = this.gameObject.GetComponent<Direction>().input_button;
        direction = this.gameObject.GetComponent<Direction>().direction;
    }
	
	// Update is called once per frame
	void Update ()
    {
        

        /// FIRING

        if (Input.GetButtonUp(input_button))
        {
           

            arrow = (GameObject)Instantiate(arrow_prefab, this.gameObject.transform.position, Quaternion.identity);


            arrowRotation = arrow.gameObject.transform.rotation.z;


            if (direction == "RIGHT")
            {

                arrowRotation = 0.0f;
                arrow.GetComponent<Rigidbody2D>().AddForce(new Vector2(arrowForce, 0), ForceMode2D.Impulse);

            }
            else if (direction == "LEFT")
            {

                arrowRotation = 180.0f;
                arrow.GetComponent<Rigidbody2D>().AddForce(new Vector2(-(arrowForce), 0), ForceMode2D.Impulse);
            }
            else if (direction == "DOWN")
            {

                arrowRotation = -90.0f;
                arrow.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -(arrowForce)), ForceMode2D.Impulse);
            }
            else if (direction == "UP")
            {

                arrowRotation = 90.0f;
                arrow.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, arrowForce), ForceMode2D.Impulse);
            }

            arrow.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, arrowRotation);




            Destroy(this.gameObject);
        }
	}
}
