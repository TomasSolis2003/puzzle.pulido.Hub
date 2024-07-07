using System.Collections;
using System.Collections.Generic;
using UnityEngine;




/*
public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f;

    private bool isMoving = true;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        if (isMoving)
        {
            // Mover el proyectil en la direcci�n positiva del eje X
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Aqu� puedes manejar la l�gica de perder el juego
            Debug.Log("Jugador ha sido golpeado. Fin del juego.");
            // Puedes llamar a un m�todo que maneje la p�rdida del juego, por ejemplo:
            // GameManager.Instance.GameOver();
        }
        isMoving = false; // Detener el movimiento cuando colisione con algo
        Destroy(gameObject);
    }
}
*/


public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f;

    private bool isMoving = true;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        if (isMoving)
        {
            // Mover el proyectil en la direcci�n positiva del eje X
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Llamar al m�todo para manejar la p�rdida del juego
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.ResetPosition();
                Debug.Log("Jugador ha sido golpeado. Fin del juego.");
            }
        }
        isMoving = false; // Detener el movimiento cuando colisione con algo
        Destroy(gameObject);
    }
}
