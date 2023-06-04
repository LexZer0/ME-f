using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControler : MonoBehaviour
{
    // ������ �� ��������� ���������� �����
    Collider2D doorCollider;

    private void Start()
    {
        // �������� ������ �� ��������� ����������
        doorCollider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // ���� ����������� � ������
        if (other.gameObject.tag == "Enemy")
        {
            // ��������� ������ ����� ����� ��� �����
            Physics2D.IgnoreCollision(other.collider, doorCollider, false);
        }
    }
}
