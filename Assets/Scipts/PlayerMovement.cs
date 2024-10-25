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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        thrust = 200.0f;
        rotationSpeed = 100.0f;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            rb.AddForce(0, 0, 1 * thrust * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            rb.AddForce(0, 0, -1 * thrust * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-1 * thrust * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb.AddForce(1 * thrust * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("PauseWindow", LoadSceneMode.Additive);
            Time.timeScale = 0f;
        }
    }

    public void CollectScore()
    {
        score++;
        thrust += 10;
        scoreText.text = "Score: " + score;
        if (score == 24)
        {
            announce.text = "Wygra�e�!";
        }
    }
}
