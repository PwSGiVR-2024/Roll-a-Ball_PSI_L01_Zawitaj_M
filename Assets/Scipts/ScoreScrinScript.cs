using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreScrinScript : MonoBehaviour
{
    public TMP_Text timeText;

    void Start()
    {
        float playthroughTime = GameManager.Instance.playthroughTime;
        if (timeText != null)
        {
            timeText.text = "Time: " + playthroughTime.ToString("F2") + "s";
        }
    }

    void Update()
    {

    }

    public void UnloadCurrentSceneAndLoadScene0()
    {
        GameManager.Instance.playthroughTime = 0f;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}



