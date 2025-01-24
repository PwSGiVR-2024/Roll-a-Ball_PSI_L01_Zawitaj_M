using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float thrust;
    public float rotationSpeed;
    public int score;
    public Text scoreText;
    public Text announce;
    public Camera mainCamera;
    private AudioSource audioSource1; // Pierwszy AudioSource
    private AudioSource audioSource2; // Drugi AudioSource

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        thrust = 200.0f;
        rotationSpeed = 100.0f;
        score = 0;
        AudioSource[] audioSources = GetComponents<AudioSource>();
        if (audioSources.Length > 1)
        {
            audioSource1 = audioSources[0];
            audioSource2 = audioSources[1];
        }

        UI.OnAllCoinsCollected += PlaySoundOnAllCoinsCollected;
    }

    void OnDestroy()
    {
        UI.OnAllCoinsCollected -= PlaySoundOnAllCoinsCollected;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseWindow();
        }

        if (Input.GetKeyDown(KeyCode.BackQuote)) // "~" key
        {
            ToggleDevConsole();
        }

        if (IsPauseWindowLoaded() || IsDevConsoleLoaded())
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    void FixedUpdate()
    {
        Vector3 forward = mainCamera.transform.forward;
        Vector3 right = mainCamera.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection -= forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection -= right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += right;
        }

        rb.AddForce(moveDirection * thrust * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space))
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DeathPlane"))
        {
            GameObject respawnPoint = GameObject.FindGameObjectWithTag("Respawn");
            if (respawnPoint != null)
            {
                transform.position = respawnPoint.transform.position;
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                if (audioSource2 != null)
                {
                    audioSource2.Play();
                }
            }
        }
    }

    void TogglePauseWindow()
    {
        if (!IsPauseWindowLoaded())
        {
            SceneManager.LoadScene(1, LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.UnloadSceneAsync(1);
        }
    }

    void ToggleDevConsole()
    {
        if (!IsDevConsoleLoaded())
        {
            SceneManager.LoadScene(8, LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.UnloadSceneAsync(8);
        }
    }

    bool IsPauseWindowLoaded()
    {
        Scene pauseScene = SceneManager.GetSceneByBuildIndex(1);
        return pauseScene.isLoaded;
    }

    bool IsDevConsoleLoaded()
    {
        Scene devConsoleScene = SceneManager.GetSceneByBuildIndex(8);
        return devConsoleScene.isLoaded;
    }

    void PlaySoundOnAllCoinsCollected()
    {
        if (audioSource1 != null)
        {
            audioSource1.Play();
        }
    }
}


