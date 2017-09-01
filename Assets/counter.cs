using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class script : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    [SerializeField]
    private Text count;

    string updateScore(int score,int increment)
    {
        score = (score + increment);
        return score.ToString();
    }
}
