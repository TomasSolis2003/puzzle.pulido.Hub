using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 checkpointPosition;

    private void Start()
    {
        // Guardar la posición inicial del jugador
        startPosition = transform.position;
        checkpointPosition = startPosition;
    }

    public void ResetPosition()
    {
        // Restablecer la posición del jugador a la posición del checkpoint
        transform.position = checkpointPosition;
        Debug.Log("Jugador restablecido a la posición del checkpoint.");
    }

    public void SetCheckpoint(Vector3 checkpoint)
    {
        checkpointPosition = checkpoint;
        Debug.Log("Checkpoint establecido en: " + checkpoint);
    }

 

    public GameObject metalBoxPrefab; // Prefab de la caja de metal
    public Transform shootPoint; // Punto desde donde se disparan las cajas desde la mano del jugador
    public float shootForce = 10f; // Fuerza con la que se disparan las cajas
    private bool hasPowerUp = false; // Indica si el jugador ha recogido el power-up

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && hasPowerUp)
        {
            Disparar();
        }
    }

    public void ActivarPowerUp()
    {
        hasPowerUp = true;
        Debug.Log("Power-up activado. Puedes disparar cajas de metal.");
    }

    private void Disparar()
    {
        if (metalBoxPrefab != null && shootPoint != null)
        {
            // Instanciar la caja de metal en el punto de disparo
            GameObject metalBox = Instantiate(metalBoxPrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody rb = metalBox.GetComponent<Rigidbody>();

            if (rb != null)
            {
                // Aplicar fuerza para disparar la caja en la dirección en la que el jugador está mirando
                rb.AddForce(shootPoint.forward * shootForce, ForceMode.Impulse);
            }
        }
        else
        {
            Debug.LogError("Prefab de la caja de metal o punto de disparo no asignado.");
        }
    }
}

   

