using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glue : MonoBehaviour
{
    public float slowDuration = 5f;
    public float slowAmount = 0.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player")) //Проверяем, что персонаж подбирает артефакт
        {
            other.GetComponent<Player>().artGlue = true;
        }
    }
}
