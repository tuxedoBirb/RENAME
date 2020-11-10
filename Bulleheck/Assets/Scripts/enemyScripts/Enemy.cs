using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy
{
    public GameObject eSprite;
    public GameObject bulletType;
    public Transform firingPoint;
    public int wT;
    public int hp;

    public Enemy(GameObject enemySprite, GameObject bul, Transform fPoint, int waitTime, int health)
    {
        eSprite = enemySprite;
        bulletType = bul;
        firingPoint = fPoint;
        wT = waitTime;
        hp = health;
    }
}

public class pewEnemy : Enemy
{
    public pewEnemy(GameObject enemySprite, GameObject bul, Transform fPoint, int waitTime, int health)
        :base(enemySprite, bul, fPoint, waitTime, health)
    {
        eSprite = enemySprite;
        bulletType = bul;
        firingPoint = fPoint;
        wT = waitTime;
        hp = health;
    }
    public void shootIt()
    {
        GameObject bullet = GameObject.Instantiate(bulletType, firingPoint.position, firingPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firingPoint.up * 50f, ForceMode2D.Impulse);
    }
}

[System.Serializable]
public class BombEnemy : Enemy
{
    public int freq;
    
    public BombEnemy(GameObject enemySprite, GameObject bul, Transform fPoint, int waitTime, int health, int frequency)
    : base(enemySprite, bul, fPoint, waitTime, health)
    {
        freq = frequency;
    }



}
