using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        offset = tranform.position - player.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = offset + player.transform.position;
        
    }
}
