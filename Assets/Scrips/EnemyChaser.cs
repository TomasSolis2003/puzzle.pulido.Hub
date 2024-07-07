/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyChaser : MonoBehaviour
{
    public Transform player; // Referencia al transform del jugador
    public float detectionRange = 10f; // Rango de detecci�n
    public float chaseSpeed = 5f; // Velocidad de persecuci�n
    public float stopDistance = 2f; // Distancia m�nima para detenerse

    private bool canSeePlayer = false;

    void Update()
    {
        if (player == null)
        {
            Debug.LogError("El jugador no est� asignado en el Inspector.");
            return;
        }

        // Comprobar si el jugador est� dentro del rango de detecci�n
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= detectionRange)
        {
            // Realizar un raycast para comprobar si el enemigo puede ver al jugador
            RaycastHit hit;
            Vector3 directionToPlayer = (player.position - transform.position).normalized;

            if (Physics.Raycast(transform.position, directionToPlayer, out hit, detectionRange))
            {
                if (hit.transform == player)
                {
                    canSeePlayer = true;
                }
                else
                {
                    canSeePlayer = false;
                }

                // Dibuja el rayo en la escena para depuraci�n
                Debug.DrawRay(transform.position, directionToPlayer * detectionRange, canSeePlayer ? Color.green : Color.red);
            }
        }
        else
        {
            canSeePlayer = false;
        }

        // Mover al enemigo hacia el jugador si puede verlo
        if (canSeePlayer)
        {
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
        // Comprobar si estamos lo suficientemente cerca del jugador
        if (Vector3.Distance(transform.position, player.position) > stopDistance)
        {
            // Moverse hacia el jugador
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * chaseSpeed * Time.deltaTime;
        }
    }
}
*/
using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    public Transform player; // Referencia al transform del jugador
    public float detectionRange = 10f; // Rango de detecci�n
    public float chaseSpeed = 5f; // Velocidad de persecuci�n
    public float stopDistance = 2f; // Distancia m�nima para detenerse

    private bool canSeePlayer = false;

    void Update()
    {
        if (player == null)
        {
            Debug.LogError("El jugador no est� asignado en el Inspector.");
            return;
        }

        // Comprobar si el jugador est� dentro del rango de detecci�n
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= detectionRange)
        {
            // Realizar un raycast para comprobar si el enemigo puede ver al jugador
            RaycastHit hit;
            Vector3 directionToPlayer = (player.position - transform.position).normalized;

            if (Physics.Raycast(transform.position, directionToPlayer, out hit, detectionRange))
            {
                if (hit.transform == player)
                {
                    canSeePlayer = true;
                }
                else
                {
                    canSeePlayer = false;
                }

                // Dibuja el rayo en la escena para depuraci�n
                Debug.DrawRay(transform.position, directionToPlayer * detectionRange, canSeePlayer ? Color.green : Color.red);
            }
        }
        else
        {
            canSeePlayer = false;
        }

        // Mover al enemigo hacia el jugador si puede verlo
        if (canSeePlayer)
        {
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
        // Comprobar si estamos lo suficientemente cerca del jugador
        if (Vector3.Distance(transform.position, player.position) > stopDistance)
        {
            // Moverse hacia el jugador
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * chaseSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Llamar al m�todo para manejar la p�rdida del juego
            GameManager.Instance.GameOver();
        }
    }
}
