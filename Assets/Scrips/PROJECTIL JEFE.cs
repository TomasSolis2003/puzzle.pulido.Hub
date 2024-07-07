using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilEnemigo : MonoBehaviour
{
    public float velocidad = 10f;        // Velocidad de movimiento del proyectil
    public int danio = 10;               // Da�o que causa el proyectil al jugador

    void Update()
    {
        // Mover el proyectil hacia adelante en direcci�n local
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);

        // Destruir el proyectil si se sale de los l�mites de la escena
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificar si el proyectil ha colisionado con el jugador
        if (other.CompareTag("Player"))
        {
            // Aplicar da�o al jugador u otro comportamiento seg�n sea necesario
            // Ejemplo: other.GetComponent<VidaJugador>().RecibirDanio(danio);

            // Destruir el proyectil al colisionar con el jugador
            Destroy(gameObject);
        }
    }
}
