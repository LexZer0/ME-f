
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
        // �������� ����������� �������� � ������
        Vector3 direction = player.position - transform.position;
        direction.Normalize();

        // ������� ����� � ����������� ������ � ������������ ���������
        transform.Translate(direction * speed * Time.deltaTime);

        // ��������� ��������������� � �������
        if (Vector3.Distance(transform.position, player.position) < 1f)
        {
            // ���� ���� ������������� � �������, ������� ���� ������
            Player playerScript = player.GetComponent<Player>();
            if (playerScript != null)
            {
                playerScript.TakeDamage(damage);
            }
        }
    }
}