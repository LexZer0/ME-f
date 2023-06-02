
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;

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
}
public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    public int damage = 10;

    private void Update()
    {
        // ѕолучаем направление движени€ к игроку
        Vector3 direction = player.position - transform.position;
        direction.Normalize();

        // ƒвигаем врага в направлении игрока с определенной скоростью
        transform.Translate(direction * speed * Time.deltaTime);

        // ѕровер€ем соприкосновение с игроком
        if (Vector3.Distance(transform.position, player.position) < 1f)
        {
            // ≈сли враг соприкасаетс€ с игроком, наносим урон игроку
            Player playerScript = player.GetComponent<Player>();
            if (playerScript != null)
            {
                playerScript.TakeDamage(damage);
            }
        }
    }
}