using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carpet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player")) //���������, ��� �������� ��������� ��������
        {
            other.GetComponent<Player>().flyOver = true;
        }
    }
}
