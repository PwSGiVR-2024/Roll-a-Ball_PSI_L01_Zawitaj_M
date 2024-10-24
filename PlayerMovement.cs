using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float thrust;
    public float rotationSpeed;
    public int score;

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
            //print("up arrow key is held down");
            rb.AddForce(0, 0, 1 * thrust * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            //print("down arrow key is held down");
            rb.AddForce(0, 0, -1 * thrust * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //print("left arrow key is held down");
            rb.AddForce(-1 * thrust * Time.deltaTime, 0, 0);
        }

        if( Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            //print("right arrow key is held down");
            rb.AddForce(1 * thrust * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            // Zatrzymanie gracza i anulowanie wszelkiego ruchu
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.Sleep(); // Upewnij si?, ?e Rigidbody jest zatrzymane
        }
    }
}
