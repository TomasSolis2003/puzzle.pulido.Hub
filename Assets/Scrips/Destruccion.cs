using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DesaparecerDespuesDeTiempo : MonoBehaviour
{
    public float tiempoParaDesaparecer = 25f; // Tiempo en segundos después del cual el objeto desaparecerá

    void Start()
    {
        // Llama al método DesaparecerObjeto después de 'tiempoParaDesaparecer' segundos
        Invoke("DesaparecerObjeto", tiempoParaDesaparecer);
    }

    void DesaparecerObjeto()
    {
        // Desactiva el objeto para que desaparezca de la escena
        gameObject.SetActive(false);
    }
}
