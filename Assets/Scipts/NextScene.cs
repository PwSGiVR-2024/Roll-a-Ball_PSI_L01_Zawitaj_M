using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UnloadAdditiveSceneAndLoadNext();
        }
    }

    void UnloadAdditiveSceneAndLoadNext()
    {
        SceneManager.UnloadSceneAsync(6);

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex;

        if (currentSceneIndex == 3)
        {
            nextSceneIndex = 4;
        }
        else if (currentSceneIndex == 4)
        {
            nextSceneIndex = 5;
        }
        else if (currentSceneIndex == 5)
        {
            nextSceneIndex = 7; // Go to victory screen
        }

        SceneManager.LoadScene(nextSceneIndex, LoadSceneMode.Single);
    }
}
















