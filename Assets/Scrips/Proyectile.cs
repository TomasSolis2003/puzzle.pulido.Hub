using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f;

    private Vector3 targetPosition;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void SetTarget(Vector3 target)
    {
        targetPosition = target;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
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

/*public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f;

    private Vector3 targetPosition;
    private bool isTargetSet = false;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void SetTarget(Vector3 target)
    {
        targetPosition = target;
        isTargetSet = true;
    }

    private void Update()
    {
        if (isTargetSet)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
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

    private void OnDestroy()
    {
        // Limpia cualquier referencia que pueda causar problemas
        isTargetSet = false;
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
            // Mover el proyectil en la dirección positiva del eje X
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
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
        isMoving = false; // Detener el movimiento cuando colisione con algo
        Destroy(gameObject);
    }
}
