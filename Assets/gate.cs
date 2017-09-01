using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gate : MonoBehaviour {

    public GameObject ball;
    public GameObject gateLeft;
    public GameObject gateRight;
    private ballMovement BallMovement;
    private bool openGates;

	// Use this for initialization
	void Start () {
        BallMovement = ball.GetComponent<ballMovement>();
        
	}
	
	// Update is called once per frame
	void Update () {
        openGates = BallMovement.allowMovement;
        if (openGates)
        {
            Color color = gateLeft.GetComponent<SpriteRenderer>().color;
            color.a = 0.2f;

            gateLeft.GetComponent<SpriteRenderer>().color = color;
            gateRight.GetComponent<SpriteRenderer>().color = color;
        }
        else
        {
            Color color = gateLeft.GetComponent<SpriteRenderer>().color;
            color.a =1f;

            gateLeft.GetComponent<SpriteRenderer>().color = color;
            gateRight.GetComponent<SpriteRenderer>().color = color;
        }
	}
}
