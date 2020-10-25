using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public Enemy[] enemies = new Enemy[2];

    public GameObject sPoint;
    public GameObject enemyObj;
    public GameObject bombDopper;
    public static int eNum;


    private int waitForIt;
    private int waves;

    // Start is called before the first frame update
    void Start(){
        Instantiate(enemyObj, sPoint.transform.position, sPoint.transform.rotation);
        waitForIt = 0;
        waves = 1;
        eNum = 0;
    }

    // Update is called once per frame
    void Update(){
        if (waves == 1)
        {
            if (waitForIt == 120)
            {
                _ = Instantiate(enemyObj, new Vector2(Random.Range(-30f, 30f), sPoint.transform.position.y), sPoint.transform.rotation);
            }
            if (waitForIt == 240)
            {
                _ = Instantiate(bombDopper, new Vector2(Random.Range(-30f, 30f), sPoint.transform.position.y), sPoint.transform.rotation);
                waitForIt = 0;
            }
        }

        if (waves == 2)
        {
            if (waitForIt == 120)
            {
                _ = Instantiate(enemyObj, new Vector2(Random.Range(-30f, 30f), sPoint.transform.position.y), sPoint.transform.rotation);
                waitForIt = 0;
            }
        }
        if (waves == 3)
        {
            if (waitForIt == 180)
            {
                _ = Instantiate(bombDopper, new Vector2(Random.Range(-30f, 30f), sPoint.transform.position.y), sPoint.transform.rotation);
                waitForIt = 0;
            }
        }


        /*if (eNum >= 30)
        {
            waves = 3;
            waitForIt = 0;
        }
        else if (eNum >= 15)
        {
            waves = 2;
            waitForIt = 0;
        }*/
        waitForIt++;
    }
}
