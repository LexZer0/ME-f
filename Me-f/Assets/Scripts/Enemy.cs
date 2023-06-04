
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
    public float KD = 0;
    private Coroutine slowCoroutine;
    public float recoilForce = 100f; // —ила отскока при попадании снар€да
    private new Collider2D collider2D;

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
        collider2D = GetComponent<Collider2D>();
    }
    private void Update()
    {
        // ѕолучаем направление движени€ к игроку
        Vector3 direction = player.gameObject.transform.position - transform.position;

        if (direction.x < 3 && direction.y < 3)
        {
            direction.Normalize();
            // ƒвигаем врага в направлении игрока с определенной скоростью
            rb.velocity = new Vector2((direction.x * speed)/2, (direction.y * speed)/2);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Arrow")
        {
            TakeDamage(playerScript.currentDamage);
            var direction = (collision.contacts[0].point - (Vector2)transform.position).normalized;
            Destroy(collision.gameObject);
            GetComponent<Rigidbody2D>().AddForce(direction * recoilForce, ForceMode2D.Impulse);
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
