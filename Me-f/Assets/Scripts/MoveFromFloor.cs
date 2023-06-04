using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MoveFromFloor : MonoBehaviour
{
    public int Floor;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {

            if (Floor == 1)
            {
                SceneManager.LoadScene("SecondFloor");
                collision.gameObject.transform.position = new Vector2(0, 0);
            }

            if (Floor == 2)
            {
                SceneManager.LoadScene("WinMenu");
                collision.gameObject.SetActive(false);
                
                UnityEngine.Cursor.lockState = CursorLockMode.None;
                UnityEngine.Cursor.visible = true;
            }

        }
    }
}
