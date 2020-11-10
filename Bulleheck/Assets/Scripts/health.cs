using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class health : MonoBehaviour
{
    public bool notInjured;
    public GameObject heart;
    public GameObject[] lives;
    public int hp;
    private SpriteRenderer sr; 

    // Start is called before the first frame update
    void Start()
    {
        hp = 3;
        notInjured = true;
        for(int i = 0; i != lives.Length; i++)
        {
            lives[i] = Instantiate(heart, new Vector2(-60, 45 - (i*10)), Quaternion.identity);
        }
        sr = GetComponent<SpriteRenderer>();

    }

    [System.Obsolete]
    // Update is called once per frame
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "doesDamage" && sr.color == Color.white)
        {
            Destroy(collision.gameObject);
            StartCoroutine(recover());
        }
    }

    [System.Obsolete]
    public IEnumerator recover()
    {
        sr.color = Color.red;
        hp -= 1;
        checkAlive(hp);
        lives[hp].active = false;

        yield return new WaitForSeconds(1);
        sr.color = Color.white;
    }

    public void checkAlive(int status)
    {
        if(status == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
