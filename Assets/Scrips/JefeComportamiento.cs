using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*public class Jefecomportamiento : MonoBehaviour
{
    public float fuerzaSalto = 10f;     // Fuerza aplicada al saltar
    public int saludMaxima = 2000;      // Salud máxima del jefe
    public int saludActual;             // Salud actual del jefe

    private Rigidbody rb;               // Componente Rigidbody del jefe
    private bool enSuelo;               // Indica si el jefe está en el suelo

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        saludActual = saludMaxima;      // Inicializa la salud actual
    }

    void Update()
    {
        // Saltar si está en el suelo y se presiona la tecla de salto (por ejemplo, barra espaciadora)
        if (enSuelo && Input.GetKeyDown(KeyCode.Space))
        {
            Saltar();
        }
    }

    void Saltar()
    {
        rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
    }

    public void RecibirDanio(int cantidadDanio)
    {
        saludActual -= cantidadDanio;

        if (saludActual <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        // Aquí puedes agregar cualquier lógica adicional al morir el jefe
        Destroy(gameObject);  // Por ejemplo, destruir el GameObject del jefe
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el jefe está en el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            enSuelo = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Verifica si el jefe ya no está en el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            enSuelo = false;
        }
    }
}
*/
/*
public class Jefe : MonoBehaviour
{
    public int salud = 2000;
    public float dashDistance = 5f; // Distancia del dash
    public float dashCooldown = 6f; // Intervalo de tiempo entre cada dash
    private float nextDashTime;
    private Renderer jefeRenderer;
    private Color originalColor;

    void Start()
    {
        nextDashTime = Time.time + dashCooldown;
        jefeRenderer = GetComponent<Renderer>();
        originalColor = jefeRenderer.material.color;
    }

    void Update()
    {
        if (Time.time >= nextDashTime)
        {
            Dash();
            nextDashTime = Time.time + dashCooldown;
        }
    }

    void Dash()
    {
        // Cambiar color a rojo
        jefeRenderer.material.color = Color.red;

        // Realizar el dash
        transform.position += transform.forward * dashDistance;

        // Restaurar el color original después del dash
        StartCoroutine(RestaurarColor());
    }

    IEnumerator RestaurarColor()
    {
        yield return new WaitForSeconds(0.1f); // Duración que el jefe permanece rojo (0.1 segundos en este caso)
        jefeRenderer.material.color = originalColor;
    }

    public void RecibirDaño(int daño)
    {
        salud -= daño;
        if (salud <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        // Aquí puedes añadir lo que quieras que pase cuando el jefe muere
        Destroy(gameObject);
    }
}
*/

/*public class Jefe : MonoBehaviour
{
    public int salud = 2000;
    public float dashDistance = 5f; // Distancia del dash
    public float dashCooldown = 6f; // Intervalo de tiempo entre cada dash
    private float nextDashTime;
    private Renderer jefeRenderer;
    private Color originalColor;
    public Transform jugador; // Referencia al jugador

    void Start()
    {
        nextDashTime = Time.time + dashCooldown;
        jefeRenderer = GetComponent<Renderer>();
        originalColor = jefeRenderer.material.color;
    }

    void Update()
    {
        if (Time.time >= nextDashTime)
        {
            Dash();
            nextDashTime = Time.time + dashCooldown;
        }
    }

    void Dash()
    {
        // Cambiar color a rojo
        jefeRenderer.material.color = Color.red;

        // Dirección hacia el jugador
        Vector3 direccionHaciaJugador = (jugador.position - transform.position).normalized;

        // Realizar el dash hacia el jugador
        transform.position += direccionHaciaJugador * dashDistance;

        // Restaurar el color original después del dash
        StartCoroutine(RestaurarColor());
    }

    IEnumerator RestaurarColor()
    {
        yield return new WaitForSeconds(0.1f); // Duración que el jefe permanece rojo (0.1 segundos en este caso)
        jefeRenderer.material.color = originalColor;
    }

    public void RecibirDaño(int daño)
    {
        salud -= daño;
        if (salud <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        // Aquí puedes añadir lo que quieras que pase cuando el jefe muere
        Destroy(gameObject);
    }
}
*/

public class JefeComportamiento : MonoBehaviour
{
    public int salud = 2000;
    public float dashDistance = 5f; // Distancia del dash
    public float dashCooldown = 6f; // Intervalo de tiempo entre cada dash
    private float nextDashTime;
    public float velocidad = 5f; // Velocidad del movimiento en zigzag
    public float amplitud = 2f; // Amplitud del zigzag
    public float frecuencia = 1f; // Frecuencia del zigzag
    private Renderer jefeRenderer;
    private Color originalColor;
    public Transform jugador; // Referencia al jugador
    private Vector3 direccionInicial;
    void Start()
    {
        nextDashTime = Time.time + dashCooldown;
        jefeRenderer = GetComponent<Renderer>();
        originalColor = jefeRenderer.material.color;
        jefeRenderer = GetComponent<Renderer>();
        originalColor = jefeRenderer.material.color;
        direccionInicial = (jugador.position - transform.position).normalized;
    }

    void Update()
    {
        if (Time.time >= nextDashTime)
        {
            Dash();
            nextDashTime = Time.time + dashCooldown;
            MovimientoZigzag();
        }
    }
    void MovimientoZigzag()
    {
        float tiempo = Time.time * frecuencia;
        Vector3 direccionZigzag = direccionInicial + new Vector3(Mathf.Sin(tiempo) * amplitud, 0, 0);
        transform.position += direccionZigzag * velocidad * Time.deltaTime;
    }
    void Dash()
    {
        // Cambiar color a rojo
        jefeRenderer.material.color = Color.red;

        // Dirección hacia el jugador
        Vector3 direccionHaciaJugador = (jugador.position - transform.position).normalized;

        // Realizar el dash hacia el jugador
        transform.position += direccionHaciaJugador * dashDistance;

        // Restaurar el color original después del dash
        StartCoroutine(RestaurarColor());
    }

    IEnumerator RestaurarColor()
    {
        yield return new WaitForSeconds(0.1f); // Duración que el jefe permanece rojo (0.1 segundos en este caso)
        jefeRenderer.material.color = originalColor;
    }

    public void RecibirDaño(int daño)
    {
        salud -= daño;
        if (salud <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        // Aquí puedes añadir lo que quieras que pase cuando el jefe muere
        Destroy(gameObject);
    }

}
