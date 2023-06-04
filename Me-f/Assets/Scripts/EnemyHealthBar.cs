using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Image healthBar;
    public float maxHealth = 100f;
    public float curHealth = 100f;

    void Start()
    {
        healthBar = GetComponent<Image>();
    }

    void Update()
    {
        healthBar.fillAmount = curHealth / maxHealth;
    }
}
