using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Artefact : MonoBehaviour
{
    public Artefact[] ArtefactRoom;
    void Start()
    {
        Artefact newRoom = Instantiate(ArtefactRoom[Random.Range(0, ArtefactRoom.Length)]);
        transform.position = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
//1) ������ �������� - ����� ��, ���� ����
//2) ����� - ���� ��������, ���� ��
//3) ������� - ���� ��������
//4) ���� -��� ��������� ����� �������� ������ ����������� �� ������������ �����
//5) ������ ������
//6) �������� - ���� ����������� ������ ��� Hole
