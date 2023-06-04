using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player")) //Проверяем, что персонаж подбирает артефакт
        {
            other.GetComponent<Player>().machineGun = true;
            Destroy(gameObject);
        }
    }
}
