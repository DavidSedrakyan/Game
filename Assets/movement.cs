using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    public Rigidbody2D rb;
    public float Force;

	// Use this for initialization
	void Start () {
        rb.velocity = new Vector2(0, -Force);
        //rb.AddForce(new Vector2(0, -Force));
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if(rb.velocity.y < 0.1 && rb.position.y > 1)
        {

            rb.velocity = new Vector2(0, -Force);
        }
	}

}
