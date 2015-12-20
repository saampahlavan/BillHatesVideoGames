using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour
{

    // Use this for initialization

    public string input_button;
    private string direction;

    void Start()
    {
        input_button = this.gameObject.GetComponent<Direction>().input_button;
        direction = this.gameObject.GetComponent<Direction>().direction;

        if (direction == "LEFT")
        {
            print("LEFT");

            this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp(input_button))
        {
            Destroy(this.gameObject);
        }
    }
}
