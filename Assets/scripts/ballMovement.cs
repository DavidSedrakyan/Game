using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ballMovement : MonoBehaviour {
    

    public double[,] Dataset = {{0.100000,0.305038,0.504228,0.697684,0.885520,1.067850,1.244788,1.416448,1.582944,1.744390,1.900900,2.052588,2.199568,2.341954,2.479860,2.613400,2.742688,2.867838,2.988964,3.106180,3.219600,3.329338,3.435508,3.538224,3.637600,3.733750,3.826788,3.916828,4.003984,4.088370,4.170100,4.249288,4.326048,4.400494,4.472740,4.542900,4.611088,4.677418,4.742004,4.804960,4.866400,4.926438,4.985188,5.042764,5.099280,5.154850,5.209588,5.263608,5.317024,5.369950,5.422500,5.474788,5.526928,5.579034,5.631220,5.683600,5.736288,5.789398,5.843044,5.897340,5.952400,6.008338,6.065268,6.123304,6.182560,6.243150,6.305188,6.368788,6.434064,6.501130,6.570100,6.641088,6.714208,6.789574,6.867300,6.947500,7.030288,7.115778,7.204084,7.295320,7.389600,7.487038,7.587748,7.691844,7.799440,7.910650,8.025588,8.144368,8.267104,8.393910,8.524900,8.660188,8.799888,8.944114,9.092980,9.246600,9.405088,9.568558,9.737124,9.910900,10,10.2
 },{0.200000,1.605880,3.015280,4.427840,5.843200,7.261000,8.680880,10.102480,11.525440,12.949400,14.374000,15.798880,17.223680,18.648040,20.071600,21.494000,22.914880,24.333880,25.750640,27.164800,28.576000,29.983880,31.388080,32.788240,34.184000,35.575000,36.960880,38.341280,39.715840,41.084200,42.446000,43.800880,45.148480,46.488440,47.820400,49.144000,50.458880,51.764680,53.061040,54.347600,55.624000,56.889880,58.144880,59.388640,60.620800,61.841000,63.048880,64.244080,65.426240,66.595000,67.750000,68.890880,70.017280,71.128840,72.225200,73.306000,74.370880,75.419480,76.451440,77.466400,78.464000,79.443880,80.405680,81.349040,82.273600,83.179000,84.064880,84.930880,85.776640,86.601800,87.406000,88.188880,88.950080,89.689240,90.406000,91.100000,91.770880,92.418280,93.041840,93.641200,94.216000,94.765880,95.290480,95.789440,96.262400,96.709000,97.128880,97.521680,97.887040,98.224600,98.534000,98.814880,99.066880,99.289640,99.482800,99.646000,99.778880,99.881080,99.952240,99.992000,100,100.8
 } };

    public Vector3 tempPosition;

    public CircleCollider2D col;

    private float sTotal;
    private float sPassed;

    public float timeTotal = 1;
    public float Gatey = 2;
    private float timeK;
    private float distanceK;

    // Use this for initialization
    void Start() {

        sTotal = Mathf.PI * R + 2 * col.radius + 2*Gatey;
        
        timeK = 10 / timeTotal;
        distanceK = 100 / sTotal;

        tempPosition = calcPosition(0);

        transform.position = tempPosition;

    }

    
    private float direction = 1;
    private float timeElapsed = 0;
    private float timeSample = 0;
    public float R,X0,Y0;

    private float acumTime;
    private float holdTime = 1;

    public bool allowMovement = false;
    private bool loopEnded = true;


    // Update is called once per frame
    void FixedUpdate() {
        if (!loopEnded) {

            timeElapsed += Time.deltaTime;

            if (timeElapsed >= timeTotal)
            {
                timeElapsed = 0;
                direction *= -1;
                loopEnded = true;
            }
            else
            {
                loopEnded = false;
            }

            timeSample = timeElapsed * timeK;

            sPassed = interpolate(Dataset, timeSample);

            sPassed = sPassed / distanceK;

            //transform.Rotate(0, 0, Mathf.Rad2Deg * sTotal / sPassed * 2* Mathf.PI, Space.World);

            tempPosition = calcPosition(sPassed);

            transform.position = tempPosition;
        }
        else if(allowMovement){
            loopEnded = false;
        }else if (!allowMovement)
        {

        }

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            closeGates();
        }
        if (Input.GetMouseButtonUp(0))
        {
            openGates();
        };


    }

    private int lastI = 0;
    public float interpolate(double[,] dataset, float time)
    {
        var newY = new double();
        for (int i = lastI; i < 101; i++)
        {           
           
            if (time <= dataset[0, i])
            {
              
                var k = (dataset[1, i] - dataset[1, i + 1]) / (dataset[0, i] - dataset[0, i + 1]);
                var b = dataset[1, i] - k * dataset[0, i];

                newY = k * time + b;

                break;

            };
        };
        return (float)newY;
    }

    private Vector3 calcPosition(float distance)
    {
        var pos = new Vector3();

        
        if (direction == -1)
        {
            distance = sTotal - distance;
        };

        if (distance <= col.radius+Gatey)
        {
            pos.x = X0-R;
            pos.y = Y0+col.radius+Gatey - distance;
        }
        else if (distance <= col.radius+Gatey + Mathf.PI * R)
        {
            distance = distance - col.radius-Gatey;
            var  angle = (float) 2*Mathf.PI * R / distance;
            angle = 2 * Mathf.PI / angle;
            pos.x = Mathf.Cos(angle)*R * -1;
            pos.y = Mathf.Sin(angle)*R * -1;
        }
        else
        {
            distance = distance - Mathf.PI * R - col.radius-Gatey;
            pos.x = X0 + R;
            pos.y = Y0 + distance;
        }

        return pos;
    }

    private Vector4 newColor;

    private void closeGates()
    {
        allowMovement = false;

    }


    private void openGates()
    {
        allowMovement = true;

    }

    private void gameOver()
    {
        allowMovement = false;
        loopEnded = true;

        direction = 1;
        timeElapsed = 0;

        tempPosition = calcPosition(0);

        transform.position = tempPosition;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "wall")
        {
            Debug.Log("TriggerEnter");
            Score = -1;
            gameOver();
        }
    }

    int Score = 0;
    [SerializeField]
    private Text count;

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "scoretrigger")
        {
            Score++;
            count.text = Score.ToString();
            string scoreString = Score.ToString();
            Debug.Log("triggerExit");
            Debug.Log(Score);
        }

    }




}