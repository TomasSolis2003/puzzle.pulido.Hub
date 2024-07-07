using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class ProjectileDown : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f;

    private Vector3 direction = Vector3.down;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection;
    }

    private void Update()
    {
        // Mover el proyectil en la dirección establecida
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Aquí puedes manejar la lógica de perder el juego
            Debug.Log("Jugador ha sido golpeado. Fin del juego.");
            // Puedes llamar a un método que maneje la pérdida del juego, por ejemplo:
            // GameManager.Instance.GameOver();
        }
        Destroy(gameObject);
    }
}
*/


public class ProjectileDown : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f;

    private Vector3 direction = Vector3.down;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection;
    }

    private void Update()
    {
        // Mover el proyectil en la dirección establecida
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Llamar al método para devolver al jugador al inicio de la escena
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.ResetPosition();
            }
        }
        Destroy(gameObject);
    }
}
