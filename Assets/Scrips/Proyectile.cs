using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
public class Projectile : MonoBehaviour
{
    public float speed = 10f; // Velocidad del proyectil
    public float lifetime = 10f; // Tiempo de vida del proyectil

    void Start()
    {
        Destroy(gameObject, lifetime); // Destruye el proyectil después de 'lifetime' segundos
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject); // Destruye al jugador
            Destroy(gameObject); // Destruye el proyectil
        }
    }
}
*/


/*public class Projectile : MonoBehaviour
{
    public float speed = 10f; // Velocidad del proyectil
    public float lifetime = 10f; // Tiempo de vida del proyectil

    void Start()
    {
        Destroy(gameObject, lifetime); // Destruye el proyectil después de 'lifetime' segundos
    }

    void Update()
    {
        // Mueve el proyectil en el eje X positivo
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject); // Destruye al jugador
            Destroy(gameObject); // Destruye el proyectil
        }
    }
}
*/



/*public class Projectile : MonoBehaviour
{
    public float speed = 10f; // Velocidad del proyectil
    public float lifetime = 10f; // Tiempo de vida del proyectil

    void Start()
    {
        Destroy(gameObject, lifetime); // Destruye el proyectil después de 'lifetime' segundos
    }

    void Update()
    {
        // Mueve el proyectil en el eje X positivo
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject); // Destruye al jugador
            Destroy(gameObject); // Destruye el proyectil
        }
    }
}
*/



/*public class Projectile : MonoBehaviour
{
    public float speed = 10f; // Velocidad del proyectil
    public float lifetime = 10f; // Tiempo de vida del proyectil
    private Vector3 direction;

    void Start()
    {
        Destroy(gameObject, lifetime); // Destruye el proyectil después de 'lifetime' segundos
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject); // Destruye al jugador
            Destroy(gameObject); // Destruye el proyectil
        }
    }
}
*/


/*public class Projectile : MonoBehaviour
{
    public float speed = 10f; // Velocidad del proyectil
    public float lifetime = 10f; // Tiempo de vida del proyectil
    private Vector3 direction;

    void Start()
    {
        Destroy(gameObject, lifetime); // Destruye el proyectil después de 'lifetime' segundos
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject); // Destruye al jugador
            Destroy(gameObject); // Destruye el proyectil
        }
    }
}*/


public class Projectile : MonoBehaviour
{
    public float speed = 10f; // Velocidad del proyectil
   // public float lifetime = 10f; // Tiempo de vida del proyectil
    private Vector3 direction;

    void Start()
    {
   //    Destroy(gameObject, lifetime); // Destruye el proyectil después de 'lifetime' segundos
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject); // Destruye al jugador
            Destroy(gameObject); // Destruye el proyectil
        }
        else if (other.CompareTag("Wall"))
        {
            Destroy(gameObject); // Destruye el proyectil al colisionar con una pared
        }
    }
}

