using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CoinMechanics : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Collider>().isTrigger = true;
        //GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 20 * Time.deltaTime, 0, Space.World);
    }
    void OnTriggerEnter(Collider collision)
    {
        collision.gameObject.GetComponent<PlayerMovement>().score++;
        
        //Debug.Log("Zdoby³eœ punk!");

        collision.gameObject.GetComponent<PlayerMovement>().thrust += 10;
        //Debug.Log(collision.gameObject.GetComponent<PlayerMovement>().thrust);

        gameObject.SetActive(false);

        if(collision.gameObject.GetComponent<PlayerMovement>().score == 80)
        {
            Debug.Log("Wygra³eœ!");
        }
    }
}
