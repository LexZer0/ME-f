
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayPressed()
    {
        SceneManager.LoadScene("FirstFloor");
    }
    public void ExitPressed()
    {
        Application.Quit();
    }
}
