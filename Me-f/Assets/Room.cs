using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject DoorN; // Up
    public GameObject DoorS; // Down
    public GameObject DoorW; // Left
    public GameObject DoorE; // Right
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RotateRandomly()
    {
        int count = Random.Range(0, 4);

        for (int i = 0; i < count; i++)
        {
            transform.Rotate(0, 0, 90);

            GameObject tmp = DoorW;
            DoorW = DoorS;
            DoorS = DoorE;
            DoorE = DoorN;
            DoorN = tmp;
        }
    }
}
