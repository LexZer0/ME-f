
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public float speed = 5f;
    public float currentSpeed;
    public int Damage = 10;
    public GameObject player;
    private Rigidbody2D rb;
    private Player playerScript;
    private Coroutine slowCoroutine;
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
        currentSpeed = speed;
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
    public void SetSlow(float duration, float amount)
    {
        if (slowCoroutine != null) 
            StopCoroutine(slowCoroutine);
        slowCoroutine = StartCoroutine(SlowCoroutine(duration, amount));
    }

    private IEnumerator SlowCoroutine(float duration, float amount)
    {
        currentSpeed *= (1 - amount);
        yield return new WaitForSeconds(duration);
        currentSpeed = speed;
        slowCoroutine = null;
    }
}
