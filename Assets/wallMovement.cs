using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallMovement : MonoBehaviour {

    public Vector3 bottom;
    public Vector3 startPosition;
    public float speed;

    private float percent;

    public bool spawnable;
    public float nextSpawnDist;

    private BoxCollider2D col;

    public spawn Spawn;
    public float size;

    // Use this for initialization
    void Start () {
        percent = 0;
        
        spawnable = true;

        bottom.y = bottom.y + size / 2;
    }
	
	// Update is called once per frame
	void FixedUpdate ()    {
        percent += speed;
        transform.position = Vector3.Lerp(startPosition, bottom, percent);

        if(startPosition.y - (transform.position.y + size) > nextSpawnDist && spawnable)
        {
            Spawn.spawnNew();
            spawnable = false;
        }

        if(percent >= 1)
        {
            //Debug.Log("destroy");
            Destroy(this.gameObject);
        }
    }
}
