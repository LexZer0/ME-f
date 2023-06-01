using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Artefact : MonoBehaviour
{
    public Artefact[] ArtefactRoom;
    void Start()
    {
        Artefact newRoom = Instantiate(ArtefactRoom[Random.Range(0, ArtefactRoom.Length)]);
        transform.position = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
//1) Синний Кристалл - минус хп, плюс урон
//2) Шприц - плюс скорость, плюс хп
//3) Кошечка - плюс здоровье
//4) Клей -при получение урона скорость врагов уменьшается на определенное время
//5) Второе оружие
//6) Артефакт - дает возможность полета над Hole
