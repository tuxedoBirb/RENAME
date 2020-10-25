//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Camera cam;
    private Rigidbody2D ownRb;

    public CollisionDetectionMode collisionDetectionMode;

    private int waiting;



    void Start()
    {
        waiting = 0;
        ownRb = GetComponent<Rigidbody2D>();
        collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    void FixedUpdate()
    {
        if (waiting <= 2)
        {
            waiting++;
        }
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.P))
        {
            if (waiting > 2)
            {
                Shoot();
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
            float curPosition = transform.position.x - 0.9f;
            transform.position = new Vector3(curPosition, transform.position.y, transform.position.z);

        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
            float curPosition = transform.position.x + 0.9f;
            transform.position = new Vector3(curPosition, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            float curPosition = transform.position.y + 0.9f;
            transform.position = new Vector3(transform.position.x, curPosition, transform.position.z);

        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            float curPosition = transform.position.y - 0.9f;
            transform.position = new Vector3(transform.position.x, curPosition, transform.position.z);
        }

    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * 250f, ForceMode2D.Impulse);
        waiting = 0;
    }

}
