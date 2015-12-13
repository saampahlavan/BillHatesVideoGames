using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

    public int damage;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {


    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            print("HITTING ENEMY");

            Enemy enemyscript = other.gameObject.GetComponent<Enemy>();
            enemyscript.health -= damage;

            Destroy(this.gameObject);
        }


    }


}
