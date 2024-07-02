using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class EndGame : MonoBehaviour
{
    public GameObject endGameCanvas; // Referencia al Canvas del mensaje de fin del juego

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            endGameCanvas.SetActive(true); // Activar el Canvas de fin del juego
            Time.timeScale = 0f; // Pausar el juego
            Debug.Log("¡Ganaste! Fin del juego");
        }
    }
}
