using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour {

    public GameObject prefab;
    public Transform spawnPostion;

    // Use this for initialization
    void Start () {
        spawnNew();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
	}

    public void spawnNew()
    {
        //create clone, get clone components
        GameObject clone = (GameObject)Instantiate(prefab, spawnPostion);
        wallMovement cloneScript = clone.GetComponent<wallMovement>();
        BoxCollider2D col = clone.GetComponent<BoxCollider2D>();

        // initialize variables for wallMovement.cs
        cloneScript.startPosition = spawnPostion.position;
        cloneScript.Spawn = this;
        cloneScript.nextSpawnDist = Random.Range(1.5f, 3);

        //calculate size, start position 
        clone.transform.localScale = new Vector3(clone.transform.localScale.x,Random.Range(1,3), clone.transform.localScale.z);
        var size = clone.GetComponent<Renderer>().bounds.size.y;

        cloneScript.size = size;
        cloneScript.startPosition.y = spawnPostion.position.y + size / 2;
        
        
    }
}
