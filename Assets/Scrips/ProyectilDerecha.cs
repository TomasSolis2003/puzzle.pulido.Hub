using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilDerecha : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        // Mover el proyectil en la dirección positiva del eje X (derecha)
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Llamar al método para manejar la pérdida del juego
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.ResetPosition();
                Debug.Log("Jugador ha sido golpeado. Fin del juego.");
            }
        }
        Destroy(gameObject);
    }
}
