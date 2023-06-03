
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public float speed = 5f;
    public int Damage = 10;
    public GameObject player;
    private Rigidbody2D rb;
    private Player playerScript;
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);

    }
    private void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
    }
    private void Update()
    {
        // ѕолучаем направление движени€ к игроку
        Vector3 direction = player.gameObject.transform.position - transform.position;
       
        if (direction.x < 3 && direction.y < 3 )
        {
            direction.Normalize();
            // ƒвигаем врага в направлении игрока с определенной скоростью
            rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Arrow")
        {
            TakeDamage(playerScript.currentDamage);
            Destroy(collision.gameObject);
        }
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            playerScript.TakeDamage(Damage);

        }
    }
}
