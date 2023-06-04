using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControler : MonoBehaviour
{
    // Ссылка на компонент коллайдера двери
    Collider2D doorCollider;

    private void Start()
    {
        // Получаем ссылку на компонент коллайдера
        doorCollider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Если столкнулись с врагом
        if (other.gameObject.tag == "Enemy")
        {
            // Блокируем проход через дверь для врага
            Physics2D.IgnoreCollision(other.collider, doorCollider, false);
        }
    }
}
