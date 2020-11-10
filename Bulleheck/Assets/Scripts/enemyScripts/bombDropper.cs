using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bDopper
{
    private float stop;
    private GameObject bomb;
    public bDopper(float s, GameObject b)
    {
        stop = s;
        bomb = b;
    }
}

public class bombDropper : MonoBehaviour
{
    public GameObject bomb;
    public int hp;
    public GameObject pPrefab;
    public GameObject hBar;

    private string phase;
    private int time;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        phase = "moving";
        time = 0;
        hp = 30;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y > 30f && phase == "moving")
        {
            float yy = transform.position.y - 0.1f;
            transform.position = new Vector2(transform.position.x, yy);
        }
        
        if (phase == "ready")
        {
            transform.position = new Vector2(Random.Range(transform.position.x - 1f, transform.position.x + 1f), Random.Range(29f, 31f));
            time++;
        }
        if (transform.position.y <= 30f && phase == "moving")
        {
            phase = "ready";
        }
        if (time > 24 && phase == "ready")
        {
            phase = "deploy";
        }
        if (phase == "deploy")
        {
            GameObject theBomb = Instantiate(bomb, transform.position, transform.rotation);
            rb = theBomb.gameObject.GetComponent<Rigidbody2D>();
            rb.gravityScale = 3f;
            phase = "recharge";
            time = 0;
        }
        if (phase == "recharge")
        {
            if (time >= 300)
            {
                phase = "ready";
                time = 0;
            }
            time++;
          
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
            Instantiate(pPrefab, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
        }
        else
        {
            hp = hp - 1;
            float shrink = 4 * hp / 30;
            hBar.gameObject.transform.localScale = new Vector3(shrink, 0.5f, 1f);
        }
    }
}
