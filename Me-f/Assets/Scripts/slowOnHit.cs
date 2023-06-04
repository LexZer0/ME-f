using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowOnHit : MonoBehaviour
{
    [SerializeField] private float slowDuration = 2f; // Длительность замедления
    [SerializeField] private float slowMultiplier = 0.5f; // Множитель замедления
    [SerializeField] private LayerMask enemyLayer; // Слой врагов
    // Вызывается при получении урона персонажем
    public void OnHit()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, 5f, enemyLayer); // Получаем все вражеские коллайдеры в радиусе 5 единиц от артефакта
        foreach (Collider2D enemy in hitEnemies)
        {
            Enemy enemyController = enemy.GetComponent<Enemy>();
            enemyController.SetSlow(slowMultiplier, slowDuration); // Применяем замедление к врагу
        }
    }
}
