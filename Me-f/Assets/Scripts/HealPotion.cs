using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPotion : MonoBehaviour
{
    public int healthRestored = 25; // ���������� ������������������ ��������

    private void OnTriggerEnter2D(Collider2D other) // ���������� ��� ������������ � ������ �����������
    {
        if (other.gameObject.CompareTag("player")) // ���� ����������� � �������
        {
            Player playerHealth = other.gameObject.GetComponent<Player>(); // �������� ������ �������� ������
            if (playerHealth != null) // ���� ������ ����������
            {
                playerHealth.Heal(healthRestored); // �������� ����� Heal � ����������� ������������������ ��������
                Destroy(gameObject); // ���������� ������ �����
            }
        }
    }
}
