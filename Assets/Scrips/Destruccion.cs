using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DesaparecerDespuesDeTiempo : MonoBehaviour
{
    public float tiempoParaDesaparecer = 25f; // Tiempo en segundos despu�s del cual el objeto desaparecer�

    void Start()
    {
        // Llama al m�todo DesaparecerObjeto despu�s de 'tiempoParaDesaparecer' segundos
        Invoke("DesaparecerObjeto", tiempoParaDesaparecer);
    }

    void DesaparecerObjeto()
    {
        // Desactiva el objeto para que desaparezca de la escena
        gameObject.SetActive(false);
    }
}
