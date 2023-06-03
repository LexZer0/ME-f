using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class syrine : MonoBehaviour
{
    public float speedMultiplier = 1.5f;
    public int health=50;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            // Увеличиваем скорость персонажа
            other.GetComponent<Player>().moveSpeed *= speedMultiplier;

            // Увеличиваем здоровье персонажа
            other.GetComponent<Player>().Heal(health);

            // Убираем артефакт со сцены
            Destroy(gameObject);
        }
    }
}
