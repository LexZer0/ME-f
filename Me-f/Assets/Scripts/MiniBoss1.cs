using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoss1 : Enemy
{
    public GameObject MFF;
    private MoveFromFloor MVF;
    void Start()
    {
        gameObject.SetActive(false);

    }
    void Die()
    {
        Destroy(gameObject);
        MFF = GameObject.Find("EscapeFromFloor");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
