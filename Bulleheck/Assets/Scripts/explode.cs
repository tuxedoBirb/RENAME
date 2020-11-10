using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour
{
    public GameObject explosion;
    private Rigidbody2D rb;
    private float stopPlace;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.rotation = Random.Range(0, 360);
        stopPlace = Random.Range(-35, 0);
    }

    // Update is called once per frame
    void Update()
    {
        rb.rotation += 7f;
        if(transform.position.y <= stopPlace)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        //(Vector2.Distance(transform.position, player.position)
    }
}
