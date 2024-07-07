using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingPlatform : MonoBehaviour
{
    public Transform pointA; // Primer punto
    public Transform pointB; // Segundo punto
    public float speed = 3f; // Velocidad de movimiento

    private Vector3 targetPosition; // Posición objetivo actual

    private void Start()
    {
        // Comenzar moviéndose hacia el punto B
        targetPosition = pointB.position;
    }

    private void Update()
    {
        // Mover la plataforma hacia la posición objetivo
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Si la plataforma ha llegado a la posición objetivo, cambiar la posición objetivo
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            if (targetPosition == pointB.position)
            {
                targetPosition = pointA.position;
            }
            else
            {
                targetPosition = pointB.position;
            }
        }
    }

    private void OnDrawGizmos()
    {
        // Dibujar las líneas en el editor para visualizar el movimiento de la plataforma
        if (pointA != null && pointB != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(pointA.position, pointB.position);
        }
    }
}
