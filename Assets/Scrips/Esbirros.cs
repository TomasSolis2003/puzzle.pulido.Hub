/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Esbirros : MonoBehaviour
{
    public float velocidadMovimiento = 5f;     // Velocidad de movimiento del esbirro
    public float frecuenciaDisparo = 1f;       // Frecuencia de disparo en segundos
    public GameObject proyectilPrefab;         // Prefab del proyectil a disparar
    public Transform puntoDisparo;             // Punto de donde se disparará el proyectil (por ejemplo, la boca del esbirro)

    private Transform jugador;                 // Referencia al transform del jugador
    private float tiempoUltimoDisparo;         // Tiempo del último disparo

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;  // Busca el jugador por la etiqueta "Player"
        tiempoUltimoDisparo = Time.time;  // Inicializa el tiempo del último disparo
    }

    void Update()
    {
        // Perseguir al jugador
        Vector3 direccion = (jugador.position - transform.position).normalized;
        transform.Translate(direccion * velocidadMovimiento * Time.deltaTime);

        // Rotar hacia la dirección del jugador (opcional)
        transform.LookAt(jugador);

        // Disparar proyectil si ha pasado el tiempo suficiente desde el último disparo
        if (Time.time - tiempoUltimoDisparo > frecuenciaDisparo)
        {
            Disparar();
            tiempoUltimoDisparo = Time.time;
        }
    }

    void Disparar()
    {
        // Instanciar un proyectil
        GameObject proyectil = Instantiate(proyectilPrefab, puntoDisparo.position, puntoDisparo.rotation);
        // Puedes ajustar la velocidad del proyectil o cualquier otra configuración aquí
        // por ejemplo:
        // proyectil.GetComponent<Rigidbody>().velocity = transform.forward * velocidadProyectil;
    }
}
*/
using UnityEngine;

public class Esbirros : MonoBehaviour
{
    public float velocidadMovimiento = 5f;     // Velocidad de movimiento del esbirro
    public float frecuenciaDisparo = 1f;       // Frecuencia de disparo en segundos
    public GameObject proyectilPrefab;         // Prefab del proyectil a disparar
    public Transform puntoDisparo;             // Punto de donde se disparará el proyectil (por ejemplo, la boca del esbirro)

    private Transform jugador;                 // Referencia al transform del jugador
    private float tiempoUltimoDisparo;         // Tiempo del último disparo

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;  // Busca el jugador por la etiqueta "Player"
        tiempoUltimoDisparo = Time.time;  // Inicializa el tiempo del último disparo
    }

    void Update()
    {
        // Perseguir al jugador
        Vector3 direccion = (jugador.position - transform.position).normalized;
        transform.Translate(direccion * velocidadMovimiento * Time.deltaTime);

        // Rotar hacia la dirección del jugador (opcional)
        transform.LookAt(jugador);

        // Disparar proyectil si ha pasado el tiempo suficiente desde el último disparo
        if (Time.time - tiempoUltimoDisparo > frecuenciaDisparo)
        {
            Disparar();
            tiempoUltimoDisparo = Time.time;
        }
    }

    void Disparar()
    {
        // Instanciar un proyectil
        GameObject proyectil = Instantiate(proyectilPrefab, puntoDisparo.position, puntoDisparo.rotation);
        // Puedes ajustar la velocidad del proyectil o cualquier otra configuración aquí
        // por ejemplo:
        // proyectil.GetComponent<Rigidbody>().velocity = transform.forward * velocidadProyectil;
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificar si el proyectil colisionó con una bala (tag "BALA")
        if (other.CompareTag("BALA"))
        {
            // Destruir el esbirro
            Destroy(gameObject);

            // Destruir también el proyectil si lo deseas
            Destroy(other.gameObject);
        }
    }
}
