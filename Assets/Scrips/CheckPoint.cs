using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*public class Checkpoint : MonoBehaviour
{
    private bool playerInRange = false;
    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        SetInactive();
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.G))
        {
            // Activar el checkpoint
            PlayerController playerController = FindObjectOfType<PlayerController>();
            if (playerController != null)
            {
                playerController.SetCheckpoint(transform.position);
                SetActive();
                Debug.Log("Checkpoint activado.");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void SetActive()
    {
        renderer.material.color = Color.green; // Cambiar el color para indicar que está activado
    }

    private void SetInactive()
    {
        renderer.material.color = Color.red; // Color inicial
    }
}
*/


public class Checkpoint : MonoBehaviour
{
    private bool playerInRange = false;
    private Renderer checkpointRenderer;

    private void Start()
    {
        checkpointRenderer = GetComponent<Renderer>();
        SetInactive();
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.G))
        {
            // Activar el checkpoint
            PlayerController playerController = FindObjectOfType<PlayerController>();
            if (playerController != null)
            {
                playerController.SetCheckpoint(transform.position);
                SetActive();
                Debug.Log("Checkpoint activado.");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void SetActive()
    {
        checkpointRenderer.material.color = Color.green; // Cambiar el color para indicar que está activado
    }

    private void SetInactive()
    {
        checkpointRenderer.material.color = Color.red; // Color inicial
    }
}
