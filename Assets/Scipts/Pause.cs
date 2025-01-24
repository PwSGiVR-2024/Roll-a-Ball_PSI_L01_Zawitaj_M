using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void UnloadScene1()
    {
        SceneManager.UnloadSceneAsync(1);
    }

    public void UnloadScene1AndLoadScene2()
    {
        SceneManager.UnloadSceneAsync(1);
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
    }

    public void UnloadAllAndLoadScene0()
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.buildIndex != 0)
            {
                SceneManager.UnloadSceneAsync(scene.buildIndex);
            }
        }
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}

