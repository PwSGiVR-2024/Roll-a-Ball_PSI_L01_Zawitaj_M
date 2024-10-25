using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("Kulka git", LoadSceneMode.Single);
    }
    public void settings()
    {

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
