using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ridLag : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "player")
        {
            Destroy(collision.gameObject);
        }
    }
}
