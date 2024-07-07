using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooterLeft : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float shootInterval = 2.0f; // Intervalo de disparo en segundos
    public float projectileSpeed = 10f; // Velocidad del proyectil

    private void Start()
    {
        if (projectilePrefab == null)
        {
            Debug.LogError("Prefab del proyectil no asignado en el Inspector.");
            return;
        }

        InvokeRepeating("Shoot", 0f, shootInterval);
    }

    private void Shoot()
    {
        if (projectilePrefab == null || shootPoint == null)
        {
            Debug.LogError("Prefab del proyectil o punto de disparo no asignado.");
            return;
        }

        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        if (projectile != null)
        {
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.left * projectileSpeed;
            }
        }
    }
}
