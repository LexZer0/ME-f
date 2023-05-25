using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomPlacer : MonoBehaviour
{
    public Room[] RoomPrefabs;
    public Room StartingRoom;

    private Room[,] spawnedRooms;

    private IEnumerator Start()
    {
        spawnedRooms = new Room[11, 11];
        spawnedRooms[5, 5] = StartingRoom;

        for (int i = 0; i < 12; i++)
        {
            yield return new WaitForSecondsRealtime(0.5f);

            PlaceOneRoom();
        }
    }

    private void PlaceOneRoom()
    {
        HashSet<Vector2Int> vacantPlaces = new HashSet<Vector2Int>();
        for (int x = 0; x < spawnedRooms.GetLength(0); x++)
        {
            for (int y = 0; y < spawnedRooms.GetLength(1); y++)
            {
                if (spawnedRooms[x, y] == null) continue;

                int maxX = spawnedRooms.GetLength(0) - 1;
                int maxY = spawnedRooms.GetLength(1) - 1;

                if (x > 0 && spawnedRooms[x - 1, y] == null) vacantPlaces.Add(new Vector2Int(x - 1, y));
                if (y > 0 && spawnedRooms[x, y - 1] == null) vacantPlaces.Add(new Vector2Int(x, y - 1));
                if (x < maxX && spawnedRooms[x + 1, y] == null) vacantPlaces.Add(new Vector2Int(x + 1, y));
                if (y < maxY && spawnedRooms[x, y + 1] == null) vacantPlaces.Add(new Vector2Int(x, y + 1));
            }
        }

        // Эту строчку можно заменить на выбор комнаты с учётом её вероятности, вроде как в ChunksPlacer.GetRandomChunk()
        Room newRoom = Instantiate(RoomPrefabs[Random.Range(0, RoomPrefabs.Length)]);

        int limit = 500;
        while (limit-- > 0)
        {
            // Эту строчку можно заменить на выбор положения комнаты с учётом того насколько он далеко/близко от центра,
            // или сколько у него соседей, чтобы генерировать более плотные, или наоборот, растянутые данжи
            Vector2Int position = vacantPlaces.ElementAt(Random.Range(0, vacantPlaces.Count));
            newRoom.RotateRandomly();

            if (ConnectToSomething(newRoom, position))
            {
                newRoom.transform.position = new Vector2(position.x - 5, position.y - 5) * 7;
                spawnedRooms[position.x, position.y] = newRoom;
                return;
            }
        }

        //Destroy(newRoom.gameObject);
    }

    private bool ConnectToSomething(Room room, Vector2Int p)
    {
        int maxX = spawnedRooms.GetLength(0) - 1;
        int maxY = spawnedRooms.GetLength(1) - 1;

        List<Vector2Int> neighbours = new List<Vector2Int>();

        if (room.DoorN != null && p.y < maxY && spawnedRooms[p.x, p.y + 1]?.DoorS != null) neighbours.Add(Vector2Int.up);
        if (room.DoorS != null && p.y > 0 && spawnedRooms[p.x, p.y - 1]?.DoorN != null) neighbours.Add(Vector2Int.down);
        if (room.DoorE != null && p.x < maxX && spawnedRooms[p.x + 1, p.y]?.DoorW != null) neighbours.Add(Vector2Int.right);
        if (room.DoorW != null && p.x > 0 && spawnedRooms[p.x - 1, p.y]?.DoorE != null) neighbours.Add(Vector2Int.left);

        if (neighbours.Count == 0) return false;

        Vector2Int selectedDirection = neighbours[Random.Range(0, neighbours.Count)];
        Room selectedRoom = spawnedRooms[p.x + selectedDirection.x, p.y + selectedDirection.y];

        if (selectedDirection == Vector2Int.up)
        {
            room.DoorN.SetActive(false);
            selectedRoom.DoorS.SetActive(false);
        }
        else if (selectedDirection == Vector2Int.down)
        {
            room.DoorS.SetActive(false);
            selectedRoom.DoorN.SetActive(false);
        }
        else if (selectedDirection == Vector2Int.right)
        {
            room.DoorE.SetActive(false);
            selectedRoom.DoorW.SetActive(false);
        }
        else if (selectedDirection == Vector2Int.left)
        {
            room.DoorW.SetActive(false);
            selectedRoom.DoorE.SetActive(false);
        }

        return true;
    }
}