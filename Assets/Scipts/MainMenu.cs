using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }

    public void settings()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
