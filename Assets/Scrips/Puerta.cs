using UnityEngine;
using System.Collections;
public class Puerta : MonoBehaviour
{
    public Transform posicionCerrada; // Posici�n cerrada de la puerta
    public Transform posicionAbierta; // Posici�n abierta de la puerta
    public float velocidadApertura = 5f; // Velocidad a la que se abre la puerta

    private Vector3 posicionInicial; // Posici�n inicial de la puerta (cerrada)
    private bool estaAbriendo = false; // Indica si la puerta est� abriendo o cerrando

    private void Start()
    {
        posicionInicial = transform.position; // Guarda la posici�n inicial como posici�n cerrada
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
        // Interpola la posici�n de la puerta desde la posici�n cerrada hacia la posici�n abierta
        while (Vector3.Distance(transform.position, posicionAbierta.position) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, posicionAbierta.position, velocidadApertura * Time.deltaTime);
            yield return null;
        }
        transform.position = posicionAbierta.position; // Asegura que la puerta est� exactamente en la posici�n abierta al finalizar
    }

    private IEnumerator CerrarPuerta()
    {
        // Interpola la posici�n de la puerta desde la posici�n abierta hacia la posici�n cerrada
        while (Vector3.Distance(transform.position, posicionCerrada.position) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, posicionCerrada.position, velocidadApertura * Time.deltaTime);
            yield return null;
        }
        transform.position = posicionCerrada.position; // Asegura que la puerta est� exactamente en la posici�n cerrada al finalizar
    }
}
