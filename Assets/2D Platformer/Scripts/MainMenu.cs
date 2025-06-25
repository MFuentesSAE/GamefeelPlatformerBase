using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int gameScene = 1;

    public void StartGame()
    {
        SceneManager.LoadScene(gameScene);  
    }
}
