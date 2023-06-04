using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoss : Enemy
{

    void Awake()
    {

    }
    void Die()
    {
       gameObject.SetActive(false);
        
    }


}
