using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int ArrowDamage = 10;
    private void Start()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        Physics2D.IgnoreLayerCollision(7, 8, true);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        //int damage=setDamage();
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(ArrowDamage);  // нанесение урона врагам при столкновении
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Walls")
        {
            Destroy(gameObject);
        }
    }
}
