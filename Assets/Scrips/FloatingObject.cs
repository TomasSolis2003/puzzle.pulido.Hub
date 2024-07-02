using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FloatingObject : MonoBehaviour
{
    public float amplitude = 0.5f; // La altura del movimiento
    public float speed = 1.0f; // La velocidad del movimiento

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position; // Guardar la posición inicial del objeto
    }

    void Update()
    {
        // Calcular la nueva posición usando Mathf.Sin
        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
