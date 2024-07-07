using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*public class EnemigoComportamiento : MonoBehaviour
{
    public Transform jugador;                // Referencia al transform del jugador
    public GameObject balaPrefab;            // Prefab de la bala que disparará el enemigo
    public float velocidadDisparo = 2f;      // Velocidad de disparo en segundos
    public float distanciaDash = 5f;         // Distancia del dash hacia adelante
    public float duracionMultiplicacion = 3f;// Duración de la multiplicación temporal

    private float tiempoUltimoDisparo;       // Tiempo del último disparo
    private bool multiplicado;               // Flag para indicar si está multiplicado

    void Start()
    {
        tiempoUltimoDisparo = Time.time;     // Inicializar tiempo del último disparo
        multiplicado = false;                // Inicialmente no está multiplicado
    }

    void Update()
    {
        // Disparar hacia la posición del jugador cada 'velocidadDisparo' segundos
        if (Time.time - tiempoUltimoDisparo > velocidadDisparo)
        {
            Disparar();
            tiempoUltimoDisparo = Time.time;
        }

        // Realizar dash hacia adelante cada 4 segundos
        if (Time.time % 4 < Time.deltaTime && !IsInvoking("DashHaciaAdelante"))
        {
            Invoke("DashHaciaAdelante", 0);
        }
    }

    void Disparar()
    {
        // Crear una instancia de la bala en la posición del enemigo
        GameObject bala = Instantiate(balaPrefab, transform.position, Quaternion.identity);

        // Calcular la dirección hacia el jugador
        Vector3 direccion = (jugador.position - transform.position).normalized;

        // Asignar velocidad y dirección a la bala
        bala.GetComponent<Rigidbody>().velocity = direccion * 10f;
    }

    void DashHaciaAdelante()
    {
        // Mover al enemigo hacia adelante
        transform.Translate(Vector3.forward * distanciaDash);

        // Multiplicar temporalmente al enemigo
        if (!multiplicado)
        {
            multiplicado = true;
            StartCoroutine(MultiplicacionTemporal());
        }
    }

    IEnumerator MultiplicacionTemporal()
    {
        // Cambiar el color o escalar al enemigo durante 'duracionMultiplicacion' segundos
        GetComponent<Renderer>().material.color = Color.red;
        transform.localScale *= 1.5f;

        // Esperar 'duracionMultiplicacion' segundos
        yield return new WaitForSeconds(duracionMultiplicacion);

        // Revertir los cambios
        GetComponent<Renderer>().material.color = Color.white;
        transform.localScale /= 1.5f;

        // Restablecer el estado multiplicado
        multiplicado = false;
    }
}
*/

public class EnemigoComportamiento : MonoBehaviour
{
    public GameObject enemigoPrefab;        // Prefab del enemigo a clonar
    public Transform jugador;               // Transform del jugador para orientar los clones
    public float intervaloMultiplicacion = 30f;  // Intervalo entre cada multiplicación
    public int cantidadMaximaClones = 3;    // Cantidad máxima de clones que puede tener el enemigo
    public float duracionMultiplicacion = 10f;   // Duración en segundos de la multiplicación
    public Color colorClones = Color.blue;  // Color de los clones

    private int cantidadClonesActuales = 0; // Cantidad actual de clones del enemigo

    void Start()
    {
        StartCoroutine(MultiplicacionAutomatica());
    }

    void Update()
    {
        // Orientar los clones hacia el jugador
        foreach (Transform hijo in transform)
        {
            hijo.LookAt(jugador.position);
        }
    }

    IEnumerator MultiplicacionAutomatica()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervaloMultiplicacion);

            // Verificar si aún se pueden crear más clones
            if (cantidadClonesActuales < cantidadMaximaClones)
            {
                MultiplicarEnemigo();
            }
        }
    }

    void MultiplicarEnemigo()
    {
        // Crear un nuevo clon del enemigo
        GameObject clon = Instantiate(enemigoPrefab, transform.position, Quaternion.identity);

        // Ajustar el color del clon
        Renderer renderer = clon.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = colorClones;
        }

        // Incrementar el contador de clones
        cantidadClonesActuales++;

        // Programar la destrucción del clon después de la duración especificada
        StartCoroutine(DestruirClonDespuesDeTiempo(clon, duracionMultiplicacion));
    }

    IEnumerator DestruirClonDespuesDeTiempo(GameObject clon, float tiempo)
    {
        yield return new WaitForSeconds(tiempo);

        // Reducir el contador de clones
        cantidadClonesActuales--;

        // Destruir el clon
        Destroy(clon);
    }
}
