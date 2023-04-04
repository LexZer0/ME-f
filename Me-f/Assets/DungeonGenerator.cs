using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonGenerator : MonoBehaviour
{
    public int mapWidth;
    public int mapHeight;
    // Длина  и ширина карты
    public int widthMinRoom;
    public int widthMaxRoom;
    // Макс и мин ширина комнат
    public int heightMinRoom;
    public int heightMaxRoom;
    // Макс и мин длина комнат
    public int maxCorridorLength; // Максимальная длина коридоров
    public int maxFeatures; // Максимальное кол-во коридоров

    public void InitializeDungeon() //Инициализация подземелья
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
