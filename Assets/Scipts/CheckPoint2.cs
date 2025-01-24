using UnityEngine;

public class CheckPoint2 : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private Light lightComponent;
    private AudioSource audioSource;
    private bool hasTriggered = false;

    void Start()
    {
        GetComponent<Collider>().isTrigger = true;
        meshRenderer = GetComponent<MeshRenderer>();
        lightComponent = GetComponent<Light>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            ChangeMaterialAndLight();
            MoveRespawnPoint();
            PlaySound();
            hasTriggered = true;
        }
    }

    void ChangeMaterialAndLight()
    {
        if (meshRenderer != null && meshRenderer.materials.Length > 1)
        {
            meshRenderer.material = meshRenderer.materials[1];
        }

        if (lightComponent != null)
        {
            lightComponent.color = Color.green;
        }
    }

    void MoveRespawnPoint()
    {
        GameObject respawnPoint = GameObject.FindGameObjectWithTag("Respawn");
        if (respawnPoint != null)
        {
            respawnPoint.transform.position = new Vector3(transform.position.x, transform.position.y + 4, transform.position.z);
        }
    }

    void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}






