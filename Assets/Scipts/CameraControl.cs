using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    public float rotationSpeed = 50.0f;

    private float rotationInput;

    void Start()
    {
        offset = transform.position - player.transform.position;
        offset.y += 4;
    }

    void Update()
    {
        rotationInput = 0f;

        if (Input.GetKey(KeyCode.Q))
        {
            rotationInput = -1f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rotationInput = 1f;
        }

        if (rotationInput != 0f)
        {
            RotateAroundPlayer(rotationInput * rotationSpeed);
        }

        transform.position = player.transform.position + offset;
        transform.LookAt(player.transform);
    }

    void RotateAroundPlayer(float speed)
    {
        Quaternion camTurnAngle = Quaternion.AngleAxis(speed * Time.deltaTime, Vector3.up);
        offset = camTurnAngle * offset;
    }
}





