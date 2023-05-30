using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject DoorU; // Up
    public GameObject DoorD; // Down
    public GameObject DoorL; // Left
    public GameObject DoorR; // Right
    public bool IsBossRoom;
    void OnEnable()
    {
        DoorU.SetActive(true);
        DoorD.SetActive(true);
        DoorL.SetActive(true);
        DoorR.SetActive(true);
    }
    


}
