using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonGenerator : MonoBehaviour
{
    public int mapWidth;
    public int mapHeight;
    // �����  � ������ �����
    public int widthMinRoom;
    public int widthMaxRoom;
    // ���� � ��� ������ ������
    public int heightMinRoom;
    public int heightMaxRoom;
    // ���� � ��� ����� ������
    public int maxCorridorLength; // ������������ ����� ���������
    public int maxFeatures; // ������������ ���-�� ���������

    public void InitializeDungeon() //������������� ����������
    {
        MapManager.map = new Tile[mapWidth, mapHeight];
    }
    void FirstRoom()
    {
        Feature room = new Feature();
        room.positions = new List<Position>();
        int roomWidth = Random.Range(widthMinRoom, widthMaxRoom);
        int roomHeight = Random.Range(heightMinRoom, heightMaxRoom);
    }

}
