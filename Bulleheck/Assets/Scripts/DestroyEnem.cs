using UnityEngine;

public class DestroyEnem : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "ignore")
        {
            Destroy(gameObject);
            enemySpawn.eNum++;
        }
        
    }
}
