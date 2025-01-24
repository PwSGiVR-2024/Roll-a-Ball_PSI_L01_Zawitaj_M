using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI Instance { get; private set; }

    public int score;
    public int totalCoins;
    public Text scoreText;
    public Text titleText;
    public Text timeText;

    public delegate void AllCoinsCollectedHandler();
    public static event AllCoinsCollectedHandler OnAllCoinsCollected;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        CoinMechanics.OnCoinCollected += UpdateUI;

        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        switch (sceneIndex)
        {
            case 3:
                SetTitle("Level 1");
                break;
            case 4:
                SetTitle("Level 2");
                break;
            case 5:
                SetTitle("Level 3");
                break;
            default:
                SetTitle("Unknown Level");
                break;
        }

        score = 0;
        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        UpdateScoreText();
    }

    void OnDestroy()
    {
        CoinMechanics.OnCoinCollected -= UpdateUI;
    }

    void Update()
    {
        UpdateTimeText();
    }

    void SetTitle(string title)
    {
        if (titleText != null)
        {
            titleText.text = title;
        }
        Debug.Log(title);
    }

    void UpdateUI()
    {
        score++;
        UpdateScoreText();
        Debug.Log("Coin collected! Score: " + score + "/" + totalCoins);

        if (score >= totalCoins)
        {
            OnAllCoinsCollected?.Invoke();

            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (sceneIndex == 3)
            {
                SceneManager.LoadScene(6, LoadSceneMode.Additive);
            }
        }
    }

    public void CollectAllCoins()
    {
        score = totalCoins;
        UpdateScoreText();
        OnAllCoinsCollected?.Invoke();

        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex == 3)
        {
            SceneManager.LoadScene(6, LoadSceneMode.Additive);
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score + "/" + totalCoins;
        }
    }

    void UpdateTimeText()
    {
        if (timeText != null)
        {
            timeText.text = "Time: " + GameManager.Instance.playthroughTime.ToString("F2") + "s";
        }
    }
}





