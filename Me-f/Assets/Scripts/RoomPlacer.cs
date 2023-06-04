using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class RoomPlacer : MonoBehaviour
{
    public Room[] RoomPrefabs;
    public Room StartingRoom;
    public Room[] BossRoomPrefabs;
    public Room[] ArtefactRoomPrefabs;
    private Room[,] spawnedRooms;


    private void Start()
    {
        spawnedRooms = new Room[11, 11];
        spawnedRooms[5, 5] = StartingRoom;
        for (int i = 0; i < 12; i++)
        {
            PlaceOneRoom();
        }
        PlaceSpawnRoom();
        PlaceBossRoom();
        PlaceArtefactRoom();

    }

    private void PlaceOneRoom()
    {
        HashSet<Vector2Int> vacantPlaces = new HashSet<Vector2Int>();
        for (int x = 0; x < spawnedRooms.GetLength(0); x++)
        {
            for (int y = 0; y < spawnedRooms.GetLength(1); y++)
            {
                if (spawnedRooms[x, y] != null) continue;

                int maxX = spawnedRooms.GetLength(0) - 1;
                int maxY = spawnedRooms.GetLength(1) - 1;

                if (x > 0 && spawnedRooms[x - 1, y] == null) vacantPlaces.Add(new Vector2Int(x - 1, y));
                if (y > 0 && spawnedRooms[x, y - 1] == null) vacantPlaces.Add(new Vector2Int(x, y - 1));
                if (x < maxX && spawnedRooms[x + 1, y] == null) vacantPlaces.Add(new Vector2Int(x + 1, y));
                if (y < maxY && spawnedRooms[x, y + 1] == null) vacantPlaces.Add(new Vector2Int(x, y + 1));
            }
        }


        Room newRoom = Instantiate(RoomPrefabs[Random.Range(0, RoomPrefabs.Length)]);

        int limit = 500;
        while (limit-- > 0)
        {

            Vector2Int position = vacantPlaces.ElementAt(Random.Range(0, vacantPlaces.Count));


            if (ConnectToSomething(newRoom, position))
            {
                newRoom.transform.position = new Vector3(position.x - 5, position.y - 5, 0) * 7;
                spawnedRooms[position.x, position.y] = newRoom;

                return;
            }
        }

        Destroy(newRoom.gameObject);
    }
    private void PlaceBossRoom()
    {
        HashSet<Vector2Int> vacantPlaces = new HashSet<Vector2Int>();
        for (int x = 0; x < spawnedRooms.GetLength(0); x++)
        {
            for (int y = 0; y < spawnedRooms.GetLength(1); y++)
            {
                if (spawnedRooms[x, y] != null) continue;

                int maxX = spawnedRooms.GetLength(0) - 1;
                int maxY = spawnedRooms.GetLength(1) - 1;

                if (x > 0 && spawnedRooms[x - 1, y] == null) vacantPlaces.Add(new Vector2Int(x - 1, y));
                if (y > 0 && spawnedRooms[x, y - 1] == null) vacantPlaces.Add(new Vector2Int(x, y - 1));
                if (x < maxX && spawnedRooms[x + 1, y] == null) vacantPlaces.Add(new Vector2Int(x + 1, y));
                if (y < maxY && spawnedRooms[x, y + 1] == null) vacantPlaces.Add(new Vector2Int(x, y + 1));
            }
        }


        Room newRoom = Instantiate(BossRoomPrefabs[Random.Range(0, BossRoomPrefabs.Length)]);

        int limit = 500;
        while (limit-- > 0)
        {

            Vector2Int position = vacantPlaces.ElementAt(Random.Range(0, vacantPlaces.Count));


            if (ConnectToSomething(newRoom, position))
            {
                newRoom.transform.position = new Vector3(position.x - 5, position.y - 5, 0) * 7;
                spawnedRooms[position.x, position.y] = newRoom;
                spawnedRooms[position.x, position.y].IsBossRoom = true;
                return;
            }
        }

        Destroy(newRoom.gameObject);
    }
    private void PlaceArtefactRoom()
    {
        HashSet<Vector2Int> vacantPlaces = new HashSet<Vector2Int>();
        for (int x = 0; x < spawnedRooms.GetLength(0); x++)
        {
            for (int y = 0; y < spawnedRooms.GetLength(1); y++)
            {
                if (spawnedRooms[x, y] != null && spawnedRooms[x, y].IsBossRoom != true) continue;

                int maxX = spawnedRooms.GetLength(0) - 1;
                int maxY = spawnedRooms.GetLength(1) - 1;

                if (x > 0 && spawnedRooms[x - 1, y] == null) vacantPlaces.Add(new Vector2Int(x - 1, y));
                if (y > 0 && spawnedRooms[x, y - 1] == null) vacantPlaces.Add(new Vector2Int(x, y - 1));
                if (x < maxX && spawnedRooms[x + 1, y] == null) vacantPlaces.Add(new Vector2Int(x + 1, y));
                if (y < maxY && spawnedRooms[x, y + 1] == null) vacantPlaces.Add(new Vector2Int(x, y + 1));
            }
        }


        Room newRoom = Instantiate(ArtefactRoomPrefabs[Random.Range(0, ArtefactRoomPrefabs.Length)]);

        int limit = 500;
        while (limit-- > 0)
        {

            Vector2Int position = vacantPlaces.ElementAt(Random.Range(0, vacantPlaces.Count));


            if (BossRoomConnectToSomething(newRoom, position))
            {
                newRoom.transform.position = new Vector3(position.x - 5, position.y - 5, 0) * 7;
                spawnedRooms[position.x, position.y] = newRoom;

                return;
            }
        }

        Destroy(newRoom.gameObject);
    }
    private void PlaceSpawnRoom()
    {
        Room newRoom = Instantiate(StartingRoom);
        newRoom.transform.position = new Vector3(0, 0, 0);
        spawnedRooms[5, 5] = newRoom;
        Vector2Int position = new Vector2Int(5, 5);
        SpawnConnectToSomething(newRoom, position);





    }
    private bool ConnectToSomething(Room room, Vector2Int p)
    {
        int maxX = spawnedRooms.GetLength(0) - 1;
        int maxY = spawnedRooms.GetLength(1) - 1;

        List<Vector2Int> neighbours = new List<Vector2Int>();

        if (room.DoorU != null && p.y < maxY && spawnedRooms[p.x, p.y + 1]?.DoorD != null) neighbours.Add(Vector2Int.up);
        if (room.DoorD != null && p.y > 0 && spawnedRooms[p.x, p.y - 1]?.DoorU != null) neighbours.Add(Vector2Int.down);
        if (room.DoorR != null && p.x < maxX && spawnedRooms[p.x + 1, p.y]?.DoorL != null) neighbours.Add(Vector2Int.right);
        if (room.DoorL != null && p.x > 0 && spawnedRooms[p.x - 1, p.y]?.DoorR != null) neighbours.Add(Vector2Int.left);

        if (neighbours.Count == 0) return false;

        Vector2Int selectedDirection = neighbours[Random.Range(0, neighbours.Count)];
        Room selectedRoom = spawnedRooms[p.x + selectedDirection.x, p.y + selectedDirection.y];

        if (selectedDirection == Vector2Int.up)
        {
            room.DoorU.SetActive(false);
            selectedRoom.DoorD.SetActive(false);
        }
        else if (selectedDirection == Vector2Int.down)
        {
            room.DoorD.SetActive(false);
            selectedRoom.DoorU.SetActive(false);
        }
        else if (selectedDirection == Vector2Int.right)
        {
            room.DoorR.SetActive(false);
            selectedRoom.DoorL.SetActive(false);
        }
        else if (selectedDirection == Vector2Int.left)
        {
            room.DoorL.SetActive(false);
            selectedRoom.DoorR.SetActive(false);
        }

        return true;
    }
    private void SpawnConnectToSomething(Room room, Vector2Int p)
    {
        if (room.DoorU != null && spawnedRooms[p.x, p.y + 1]?.DoorD != null)
        {
            Room selectedRoom = spawnedRooms[p.x, p.y + 1];
            room.DoorU.SetActive(false);
            selectedRoom.DoorD.SetActive(false);
        }
        if (room.DoorD != null && spawnedRooms[p.x, p.y - 1]?.DoorU != null)
        {
            Room selectedRoom = spawnedRooms[p.x, p.y - 1];
            room.DoorD.SetActive(false);
            selectedRoom.DoorU.SetActive(false);
        }
        if (room.DoorR != null && spawnedRooms[p.x + 1, p.y]?.DoorL != null)
        {
            Room selectedRoom = spawnedRooms[p.x + 1, p.y];
            room.DoorR.SetActive(false);
            selectedRoom.DoorL.SetActive(false);
        }
        if (room.DoorL != null && spawnedRooms[p.x - 1, p.y]?.DoorR != null)
        {
            Room selectedRoom = spawnedRooms[p.x - 1, p.y];
            room.DoorL.SetActive(false);
            selectedRoom.DoorR.SetActive(false);
        }

        return;
    }
    private bool BossRoomConnectToSomething(Room room, Vector2Int p)
    {
        int maxX = spawnedRooms.GetLength(0) - 1;
        int maxY = spawnedRooms.GetLength(1) - 1;

        List<Vector2Int> neighbours = new List<Vector2Int>();

        if (room.DoorU != null && p.y < maxY && spawnedRooms[p.x, p.y + 1]?.DoorD != null && spawnedRooms[p.x, p.y + 1].IsBossRoom != true) neighbours.Add(Vector2Int.up);
        if (room.DoorD != null && p.y > 0 && spawnedRooms[p.x, p.y - 1]?.DoorU != null && spawnedRooms[p.x, p.y - 1].IsBossRoom != true) neighbours.Add(Vector2Int.down);
        if (room.DoorR != null && p.x < maxX && spawnedRooms[p.x + 1, p.y]?.DoorL != null && spawnedRooms[p.x + 1, p.y].IsBossRoom != true) neighbours.Add(Vector2Int.right);
        if (room.DoorL != null && p.x > 0 && spawnedRooms[p.x - 1, p.y]?.DoorR != null && spawnedRooms[p.x - 1, p.y].IsBossRoom != true) neighbours.Add(Vector2Int.left);

        if (neighbours.Count == 0) return false;

        Vector2Int selectedDirection = neighbours[Random.Range(0, neighbours.Count)];
        Room selectedRoom = spawnedRooms[p.x + selectedDirection.x, p.y + selectedDirection.y];

        if (selectedDirection == Vector2Int.up)
        {
            room.DoorU.SetActive(false);
            selectedRoom.DoorD.SetActive(false);
        }
        else if (selectedDirection == Vector2Int.down)
        {
            room.DoorD.SetActive(false);
            selectedRoom.DoorU.SetActive(false);
        }
        else if (selectedDirection == Vector2Int.right)
        {
            room.DoorR.SetActive(false);
            selectedRoom.DoorL.SetActive(false);
        }
        else if (selectedDirection == Vector2Int.left)
        {
            room.DoorL.SetActive(false);
            selectedRoom.DoorR.SetActive(false);
        }
        return true;
    }
}