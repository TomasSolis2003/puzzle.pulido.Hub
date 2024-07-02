using UnityEngine;
using System.Collections;
public class Puerta : MonoBehaviour
{
    public Transform posicionCerrada; // Posición cerrada de la puerta
    public Transform posicionAbierta; // Posición abierta de la puerta
    public float velocidadApertura = 5f; // Velocidad a la que se abre la puerta

    private Vector3 posicionInicial; // Posición inicial de la puerta (cerrada)
    private bool estaAbriendo = false; // Indica si la puerta está abriendo o cerrando

    private void Start()
    {
        posicionInicial = transform.position; // Guarda la posición inicial como posición cerrada
    }

    public void Abrir()
    {
        if (!estaAbriendo)
        {
            estaAbriendo = true;
            // Inicia la corutina para abrir la puerta
            StartCoroutine(AbrirPuerta());
        }
    }

    public void Cerrar()
    {
        if (estaAbriendo)
        {
            estaAbriendo = false;
            // Inicia la corutina para cerrar la puerta
            StartCoroutine(CerrarPuerta());
        }
    }

    private IEnumerator AbrirPuerta()
    {
        // Interpola la posición de la puerta desde la posición cerrada hacia la posición abierta
        while (Vector3.Distance(transform.position, posicionAbierta.position) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, posicionAbierta.position, velocidadApertura * Time.deltaTime);
            yield return null;
        }
        transform.position = posicionAbierta.position; // Asegura que la puerta esté exactamente en la posición abierta al finalizar
    }

    private IEnumerator CerrarPuerta()
    {
        // Interpola la posición de la puerta desde la posición abierta hacia la posición cerrada
        while (Vector3.Distance(transform.position, posicionCerrada.position) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, posicionCerrada.position, velocidadApertura * Time.deltaTime);
            yield return null;
        }
        transform.position = posicionCerrada.position; // Asegura que la puerta esté exactamente en la posición cerrada al finalizar
    }
}
