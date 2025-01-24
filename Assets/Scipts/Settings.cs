using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void BackToPreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 3 || currentSceneIndex == 4 || currentSceneIndex == 5)
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByBuildIndex(2));
        }
        else
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByBuildIndex(2));
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}
