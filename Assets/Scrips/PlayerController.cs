using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Vector3 startPosition;

    private void Start()
    {
        // Guardar la posición inicial del jugador
        startPosition = transform.position;
    }

    public void ResetPosition()
    {
        // Restablecer la posición del jugador a la posición inicial
        transform.position = startPosition;
    }
}
