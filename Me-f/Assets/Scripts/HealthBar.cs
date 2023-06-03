using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    private Player playerScript;
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
    }

  
    void Update()
    {
        animator.SetFloat("Health", playerScript.Health);
    }
}
