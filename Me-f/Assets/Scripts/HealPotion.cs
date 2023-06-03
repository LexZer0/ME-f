using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPotion : MonoBehaviour
{
    public int healthRestored = 25; // количество восстанавливаемого здоровь€

    private void OnTriggerEnter2D(Collider2D other) // вызываетс€ при столкновении с другим коллайдером
    {
        if (other.gameObject.CompareTag("player")) // если столкнулись с игроком
        {
            Player playerHealth = other.gameObject.GetComponent<Player>(); // получаем скрипт здоровь€ игрока
            if (playerHealth != null) // если скрипт существует
            {
                playerHealth.Heal(healthRestored); // вызываем метод Heal с количеством восстанавливаемого здоровь€
                Destroy(gameObject); // уничтожаем объект зель€
            }
        }
    }
}
