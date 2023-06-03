using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int health = 100;
    public float speed = 5f;
    public int damage = 10;
    public GameObject player;
    private Rigidbody2D rb;
    private Player playerScript;
    public GameObject enemyPrefab;
    public int numEnemies = 3; //  оличество новых противников после смерти

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Update()
    {
        // ѕолучаем направление движени€ к игроку
        Vector3 direction = player.gameObject.transform.position - transform.position;
        direction.Normalize();

        // ƒвигаем врага в направлении игрока с определенной скоростью
        rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
        //transform.Translate(direction * speed * Time.deltaTime);
     
    }
    void Die()
    {
        Destroy(gameObject);
        for (int i = 0; i < numEnemies; i++)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }
}