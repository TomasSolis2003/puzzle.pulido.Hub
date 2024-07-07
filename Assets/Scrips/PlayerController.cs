using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Vector3 startPosition;

    private void Start()
    {
        // Guardar la posici�n inicial del jugador
        startPosition = transform.position;
    }

    public void ResetPosition()
    {
        // Restablecer la posici�n del jugador a la posici�n inicial
        transform.position = startPosition;
    }
}
