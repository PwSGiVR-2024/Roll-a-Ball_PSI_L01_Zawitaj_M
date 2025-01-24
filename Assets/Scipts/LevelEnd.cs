using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour
{
    public delegate void LevelEndHandler();
    public static event LevelEndHandler OnLevelEnd;

    private bool isTriggered = false;
    private bool allCoinsCollected = false;
    private MeshRenderer meshRenderer;
    private Light lightComponent;

    void Start()
    {
        GetComponent<Collider>().isTrigger = true;
        meshRenderer = GetComponent<MeshRenderer>();
        lightComponent = GetComponent<Light>();
        UI.OnAllCoinsCollected += SwitchMaterial;
    }

    void OnDestroy()
    {
        UI.OnAllCoinsCollected -= SwitchMaterial;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (!isTriggered && collision.gameObject.GetComponent<PlayerMovement>() != null && allCoinsCollected)
        {
            isTriggered = true;
            OnLevelEnd?.Invoke();
            if (!IsSceneLoaded(6))
            {
                SceneManager.LoadScene(6, LoadSceneMode.Additive);
            }
        }
    }

    bool IsSceneLoaded(int sceneBuildIndex)
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (SceneManager.GetSceneAt(i).buildIndex == sceneBuildIndex)
            {
                return true;
            }
        }
        return false;
    }

    void SwitchMaterial()
    {
        allCoinsCollected = true;

        if (meshRenderer != null && meshRenderer.materials.Length > 1)
        {
            meshRenderer.material = meshRenderer.materials[1];
        }

        if (lightComponent != null)
        {
            lightComponent.color = Color.green;
        }
    }
}


