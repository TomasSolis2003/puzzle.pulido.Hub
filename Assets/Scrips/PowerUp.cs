using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PowerUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Otorgar al jugador la habilidad de disparar cajas de metal
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.ActivarPowerUp();
                Destroy(gameObject); // Destruir el power-up después de recogerlo
            }
        }
    }
}
