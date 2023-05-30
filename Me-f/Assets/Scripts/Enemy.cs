using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
}

private void OnTriggerEnter2D(Collider 2D collision)
{
    if (collision.gameObject == "Arrow")
    {
        Destroy(gameObject);
    }
}
