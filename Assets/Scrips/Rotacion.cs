using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotacionSimple : MonoBehaviour
{
    public float velocidadRotacion = 50f; // Velocidad de rotación en grados por segundo

    void Update()
    {
        // Rotar el objeto en el eje Y (vertical) constantemente
        transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);
    }
}
