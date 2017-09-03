using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tapToPlay : MonoBehaviour {

    // Use this for initialization

    public Transform canvas;
	void Start () {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
