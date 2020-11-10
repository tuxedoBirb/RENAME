using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class enemyAI : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject pPrefab;
    public GameObject hBar;

    public int hp;      

    private int waiting;
    private float moving;

    void Start()
    {
        waiting = 0;
        moving = UnityEngine.Random.Range(-2f, 2f);
        hp = 5;
    }

    void FixedUpdate()
    {
        if (waiting <= 30){
            waiting++;
        }
        else{
            Shoot();
            waiting = 0;
        }
        float xx = transform.position.x + moving;
        float yy = transform.position.y - 0.05f;
        transform.position = new Vector3(xx, yy, transform.position.z);

        if (transform.position.x < -30.0f){
            moving = UnityEngine.Random.Range(0.1f, 0.5f);
        }
        else if (transform.position.x > 30.0f)
        {
            moving = UnityEngine.Random.Range(0.1f, 0.5f) * - 1f;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * 50f, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (hp <= 1)
        {
            Destroy(gameObject);
            Instantiate(pPrefab, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
        }
        else {
            hp = hp - 1;
            float shrink = 0.8f * hp;
            hBar.gameObject.transform.localScale = new Vector3(shrink, 0.5f, 0f);
        }
    }
}
