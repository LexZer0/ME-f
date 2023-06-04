using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BossRoom : Room
{
    public int Floor = 1;
    public int i = 0;
    public MoveFromFloor Hatch;
    private GameObject[] MB;
    private void Update()
    {
        MB = GameObject.FindGameObjectsWithTag("MiniBoss");
        if (MB.GetLength(0) != 0)
        {
            i = 1;
        }
        if (MB.GetLength(0) == 0 && i == 1)
        {
            i = 2;
        }


        if (Floor == 1 && i == 2)
        {
            Hatch.transform.position = gameObject.transform.position;
            Instantiate(Hatch);
            Hatch.Floor = 1;
            i = 3;
        }
        if (Floor == 2 && i == 2)
        {
            Hatch.transform.position = gameObject.transform.position;
            Hatch.Floor = 2;
            Instantiate(Hatch);
            i = 3;
        }
    }
}
