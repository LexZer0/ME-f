using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public int healthIncrease = 50; //Значение увелечения здоровья

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player")) //Проверяем, что персонаж подбирает артефакт
        {
            Player boost = other.GetComponent<Player>();
            boost.MaxHealth += healthIncrease; //Увеличиваем урон персонажа на заданную величину
            boost.Health += healthIncrease;
            Destroy(gameObject); //Уничтожаем объект артефакта
        }
    }
}
