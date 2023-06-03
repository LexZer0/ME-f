using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowOnHit : MonoBehaviour
{
    [SerializeField] private float slowDuration = 2f; // ������������ ����������
    [SerializeField] private float slowMultiplier = 0.5f; // ��������� ����������
    [SerializeField] private LayerMask enemyLayer; // ���� ������
    // ���������� ��� ��������� ����� ����������
    public void OnHit()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, 5f, enemyLayer); // �������� ��� ��������� ���������� � ������� 5 ������ �� ���������
        foreach (Collider2D enemy in hitEnemies)
        {
            Enemy enemyController = enemy.GetComponent<Enemy>();
            enemyController.SetSlow(slowMultiplier, slowDuration); // ��������� ���������� � �����
        }
    }
}
