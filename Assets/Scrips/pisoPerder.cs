using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SurfaceLoseTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Llamar al método para manejar la pérdida del juego
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.ResetPosition();
                Debug.Log("Jugador ha atravesado la superficie de pérdida. Fin del juego.");
            }
        }
    }
}
