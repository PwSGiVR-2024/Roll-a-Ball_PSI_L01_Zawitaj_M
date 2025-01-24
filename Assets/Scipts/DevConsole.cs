using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DevConsole : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text historyText;

    private string[] cheatCommands = new string[]
    {
        "/coins",
        "/skip",
        "/help",
        "/back"
    };

    void Start()
    {
        inputField.onSubmit.AddListener(CheckCheatCommand);
        ActivateInputField();
    }

    void OnDestroy()
    {
        inputField.onSubmit.RemoveListener(CheckCheatCommand);
    }

    void CheckCheatCommand(string command)
    {
        command = command.ToLower().Trim();
        AddToHistory(command);

        if (command == cheatCommands[0])
        {
            CollectAllCoins();
        }
        else if (command == cheatCommands[1])
        {
            SceneManager.LoadScene(6, LoadSceneMode.Additive);
        }
        else if (command == cheatCommands[2])
        {
            PrintHelp();
        }
        else if (command == cheatCommands[3])
        {
            CloseConsole();
        }
        else
        {
            AddToHistory("Unknown command. Type /help for a list of commands.");
        }

        inputField.text = string.Empty;
        ActivateInputField();
    }

    void CollectAllCoins()
    {
        UI.Instance.CollectAllCoins();
    }

    void PrintHelp()
    {
        string helpText = "Available commands:\n";
        foreach (string cmd in cheatCommands)
        {
            helpText += cmd + "\n";
        }
        AddToHistory(helpText);
    }

    void AddToHistory(string message)
    {
        if (historyText != null)
        {
            historyText.text += message + "\n";
        }
    }

    void ActivateInputField()
    {
        inputField.Select();
        inputField.ActivateInputField();
    }

    void CloseConsole()
    {
        SceneManager.UnloadSceneAsync(8);
    }
}










