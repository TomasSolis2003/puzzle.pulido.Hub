using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MultiplicadorJefe : MonoBehaviour
{
    public GameObject jefePrefab; // Referencia al prefab del jefe que se multiplicará
    public float duracionMultiplicacion = 20f; // Duración en segundos que durará la multiplicación
    public float frecuenciaMultiplicacion = 1f; // Frecuencia en segundos a la que se crean los clones

    private float tiempoActual = 0f;
    private bool multiplicando = false;

    void Update()
    {
        if (!multiplicando)
        {
            StartCoroutine(MultiplicarJefe());
        }
    }

    IEnumerator MultiplicarJefe()
    {
        multiplicando = true;
        tiempoActual = 0f;

        while (tiempoActual < duracionMultiplicacion)
        {
            GameObject nuevoJefe = Instantiate(jefePrefab, transform.position, Quaternion.identity);
            // Cambiar el color del nuevo jefe a azul
            Renderer renderer = nuevoJefe.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = Color.blue;
            }

            yield return new WaitForSeconds(frecuenciaMultiplicacion);
            tiempoActual += frecuenciaMultiplicacion;
        }

        multiplicando = false;
    }
}
