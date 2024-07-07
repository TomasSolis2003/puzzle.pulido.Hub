using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class EnemyShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float shootInterval = 2.0f; // Intervalo de disparo en segundos
    public Vector3 targetPosition;

    void Start()
    {
        InvokeRepeating("Shoot", 0f, shootInterval);
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        Projectile projScript = projectile.GetComponent<Projectile>();
        if (projScript != null)
        {
            projScript.SetTarget(targetPosition);
        }
    }
}
*/


public class EnemyShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float shootInterval = 2.0f; // Intervalo de disparo en segundos
    public Vector3 targetPosition;

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
  //          Debug.LogError("Prefab del proyectil o punto de disparo no asignado.");
            return;
        }

        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        if (projectile != null)
        {
            Projectile projScript = projectile.GetComponent<Projectile>();
            if (projScript != null)
            {
        //        projScript.SetTarget(targetPosition);
            }
        }
    }
}
