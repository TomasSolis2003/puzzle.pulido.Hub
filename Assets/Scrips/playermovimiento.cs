using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class playermovimiento : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f; // Velocidad de movimiento del jugador
    public float velocidadSalto = 5.0f; // Velocidad de salto del jugador
    public bool puedeSaltar = true; // Controla si el jugador puede saltar
    public float escalaAgachado = 0.2f; // Escala en Y al agacharse
    public KeyCode teclaAgacharse = KeyCode.C; // Tecla para agacharse

    private Rigidbody rb;
    private Vector3 escalaOriginal; // Escala original del jugador
    private bool estaAgachado = false; // Estado agachado

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtener el componente Rigidbody
        escalaOriginal = transform.localScale; // Guardar la escala original del jugador
    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento horizontal y vertical
        float movimientoHorizontal = Input.GetAxis("Horizontal") * velocidadMovimiento;
        float movimientoVertical = Input.GetAxis("Vertical") * velocidadMovimiento;

        // Aplicar movimiento
        Vector3 movimiento = new Vector3(movimientoHorizontal, rb.velocity.y, movimientoVertical);
        rb.velocity = movimiento;

        // Saltar
        if (Input.GetButtonDown("Jump") && puedeSaltar)
        {
            rb.AddForce(Vector3.up * velocidadSalto, ForceMode.Impulse);
        }

        // Agacharse
        if (Input.GetKeyDown(teclaAgacharse))
        {
            Agacharse();
        }
        if (Input.GetKeyUp(teclaAgacharse))
        {
            Levantarse();
        }
    }

    private void Agacharse()
    {
        if (!estaAgachado)
        {
            transform.localScale = new Vector3(transform.localScale.x, escalaAgachado, transform.localScale.z);
            estaAgachado = true;
        }
    }

    private void Levantarse()
    {
        if (estaAgachado)
        {
            transform.localScale = escalaOriginal;
            estaAgachado = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Detectar colisión con el suelo para permitir saltar de nuevo
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("CAJA"))
        {
            puedeSaltar = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Detectar cuando el jugador deja de tocar el suelo o una caja
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("CAJA"))
        {
            puedeSaltar = false;
        }
    }
}
