using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCrystal : MonoBehaviour
{
    public int damageIncrease = 5; //Увеличение урона при подборе артефакта
    public int healthDecrease = 10;//Значение уменьшения здоровья

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player")) //Проверяем, что персонаж подбирает артефакт
        {
            Player boost = other.GetComponent<Player>();
            boost.currentDamage += damageIncrease; //Увеличиваем урон персонажа на заданную величину
            Arrow arrowDamage = other.GetComponent<Arrow>();
            arrowDamage.ArrowDamage += damageIncrease;
            boost.Health -= healthDecrease; //Уменьшаем текущее здоровье
            Destroy(gameObject); //Уничтожаем объект артефакта
        }
    }
}
