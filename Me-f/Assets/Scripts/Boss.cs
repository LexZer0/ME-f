using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int health = 100;
    public float speed = 5f;
    public int Damage = 10;
    public GameObject player;
    private Rigidbody2D rb;
    private Player playerScript;
    public GameObject enemyPrefab;
    public MiniBoss[] miniBosses;
    public float KD = 0;
    Vector3 position;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
        position = gameObject.transform.position;
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

        if (direction.x < 3 && direction.y < 3)
        {
            direction.Normalize();
            // ƒвигаем врага в направлении игрока с определенной скоростью
            rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
        }
    }
    void Die()
    {
        for (int i = 0; i < miniBosses.GetLength(0); i++)
        { 
            miniBosses[i].transform.position = new Vector3(Random.Range(position.x - 2, position.x + 2), Random.Range(position.y - 2, position.y + 2), Random.Range(position.z - 2, position.z + 2));
            Instantiate(miniBosses[i]);
        }
        gameObject.SetActive(false);
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
        if (KD > 0)
        {
            KD -= Time.deltaTime;
        }

        if (collision.gameObject.tag == "player")
        {
            if (KD <= 0)
            {
                playerScript.TakeDamage(Damage);
                KD = 1;
            }
        }
    }
}
