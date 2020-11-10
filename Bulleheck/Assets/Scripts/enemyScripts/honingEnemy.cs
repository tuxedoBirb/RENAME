using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class honingEnemy : MonoBehaviour
{
    public GameObject player;
    public Transform goHere;

    public LineRenderer LRen;

    private bool targetFound;

    [System.Obsolete]
    void Start()
    {
        goHere = player.transform;
        transform.position = new Vector2(Random.Range(-30, 30), 70);
        LRen = GetComponent<LineRenderer>();
        targetFound = true;

    }

    void Update()
    {
        if (transform.position.y > 20)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.1f);
        }
        else
        {
            if(targetFound)
            {
                goHere = transform;
                LRen.SetPosition(0, new Vector3(transform.position.x, transform.position.y, -10));
                LRen.SetPosition(1, new Vector3(player.transform.position.x*1.5f, player.transform.position.y*1.5f, -10));
                targetFound = false;
            }
            else
            {
                StartCoroutine(Test());
                transform.Rotate(0, 0, 1);
                transform.position = new Vector2(Random.Range(goHere.position.x - 0.1f, goHere.position.x + 0.1f), Random.Range(goHere.position.y - 0.1f, goHere.position.y + 0.1f));
                RaycastHit2D hit = Physics2D.Linecast(LRen.GetPosition(0), LRen.GetPosition(1));
                if(hit.collider != null && hit.collider.gameObject.CompareTag("player"))
                {
                    //health.recover();
                }
            }
        }
    }

    IEnumerator Test()
    {
        yield return new WaitForSeconds(2);
    }
}
