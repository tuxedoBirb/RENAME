using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy
{
    public GameObject eSprite;
    public int bulletType;
    public Transform firingPoint;
    public int wT;
    public int freq;

    public Enemy(GameObject enemySprite, int bul, Transform fPoint, int waitTime)
    {
        bulletType = bul;
        firingPoint = fPoint;
        wT = waitTime;
        eSprite = enemySprite;
    }
    public Enemy(GameObject enemySprite, int bul, Transform fPoint, int waitTime, int frequency)
    {
        bulletType = bul;
        firingPoint = fPoint;
        wT = waitTime;
        eSprite = enemySprite;
        freq = frequency;
    }
    public void shootIt()
    {
        //GameObject bullet = Instantiate(bulletType, firePoint.position, firePoint.rotation);
        //Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //rb.AddForce(firePoint.up * 50f, ForceMode2D.Impulse);
    }
}
