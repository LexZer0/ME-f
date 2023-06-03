using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public int healthIncrease = 50; //�������� ���������� ��������

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player")) //���������, ��� �������� ��������� ��������
        {
            Player boost = other.GetComponent<Player>();
            boost.MaxHealth += healthIncrease; //����������� ���� ��������� �� �������� ��������
            boost.Health += healthIncrease;
            Destroy(gameObject); //���������� ������ ���������
        }
    }
}
