using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();

    public GameObject sPoint;
    public GameObject enemyObj;
    public GameObject bombDopper;
    public GameObject bullet;
    public static int eNum;


    private int waitForIt;

    // Start is called before the first frame update
    void Start(){
        Instantiate(enemyObj, sPoint.transform.position, sPoint.transform.rotation);
        waitForIt = 0;
        eNum = 0;
    }

    // Update is called once per frame
    // .add TO ADD ITEMS TO LIST
    void Update(){

        if (waitForIt == 200 || waitForIt == 400 || waitForIt == 600 || waitForIt == 800)
        {
            GameObject pewpew;
            pewpew = Instantiate(enemyObj, new Vector2(Random.Range(-30f, 30f), sPoint.transform.position.y), sPoint.transform.rotation);
            enemies.Add(new Enemy(pewpew, bullet, pewpew.transform.GetChild(0), 30, 10));
        }
        if (waitForIt == 1000)
        {
            _ = Instantiate(bombDopper, new Vector2(Random.Range(-30f, 30f), sPoint.transform.position.y), sPoint.transform.rotation);
            waitForIt = 0;
        }

        waitForIt++;
    }
}
