using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
    
    public void ReplayGame()
    {
        SceneManager.LoadScene("Jeepney-PHiride");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
