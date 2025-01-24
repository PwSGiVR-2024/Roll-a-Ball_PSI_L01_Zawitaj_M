using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMechanics : MonoBehaviour
{
    public delegate void CoinCollectedHandler();
    public static event CoinCollectedHandler OnCoinCollected;

    private AudioSource audioSource;
    private MeshRenderer meshRenderer;

    void Start()
    {
        GetComponent<Collider>().isTrigger = true;
        audioSource = GetComponent<AudioSource>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        transform.Rotate(0, 20 * Time.deltaTime, 0, Space.World);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            OnCoinCollected?.Invoke();
            if (audioSource != null)
            {
                audioSource.Play();
            }
            StartCoroutine(DisableAfterDelay(1.5f));
        }
    }

    IEnumerator DisableAfterDelay(float delay)
    {
        if (meshRenderer != null)
        {
            meshRenderer.enabled = false;
        }
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}





























