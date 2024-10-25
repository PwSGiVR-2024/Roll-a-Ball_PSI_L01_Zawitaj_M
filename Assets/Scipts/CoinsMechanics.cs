using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CoinMechanics : MonoBehaviour
{

    void Start()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    void Update()
    {
        transform.Rotate(0, 20 * Time.deltaTime, 0, Space.World);
    }
   
    void OnTriggerEnter(Collider collision)
    {
        collision.gameObject.GetComponent<PlayerMovement>().CollectScore();


        gameObject.SetActive(false);
    }
}
