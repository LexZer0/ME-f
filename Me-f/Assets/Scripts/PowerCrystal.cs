using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCrystal : MonoBehaviour
{
    public int damageIncrease = 5; //���������� ����� ��� ������� ���������
    public int healthDecrease = 10;//�������� ���������� ��������

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player")) //���������, ��� �������� ��������� ��������
        {
            Player boost = other.GetComponent<Player>();
            boost.currentDamage += damageIncrease; //����������� ���� ��������� �� �������� ��������
            Arrow arrowDamage = other.GetComponent<Arrow>();
            arrowDamage.ArrowDamage += damageIncrease;
            boost.Health -= healthDecrease; //��������� ������� ��������
            Destroy(gameObject); //���������� ������ ���������
        }
    }
}
