using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*public class EnemyShoot : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform firePoint; // Punto desde donde se disparan los proyectiles
    public float fireRate = 2f; // Tasa de disparo en segundos
    private float nextFireTime = 0f;

    void Update()
    {
        if (Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }
}
*/

/*public class EnemyShoot : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform firePoint; // Punto desde donde se disparan los proyectiles
    public float fireRate = 2f; // Tasa de disparo en segundos
    private float nextFireTime = 0f;

    void Update()
    {
        if (Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        }
        else
        {
            Debug.LogWarning("El prefab del proyectil o el firePoint no están asignados.");
        }
    }
}
*/



/*public class EnemyShoot : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform firePoint; // Punto desde donde se disparan los proyectiles
    public float fireRate = 2f; // Tasa de disparo en segundos
    private float nextFireTime = 0f;
    public Vector3 targetDirection = Vector3.right; // Dirección fija de disparo (eje X positivo)

    void Update()
    {
        if (Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
            projectile.GetComponent<Projectile>().SetDirection(targetDirection);
        }
        else
        {
            Debug.LogWarning("El prefab del proyectil o el firePoint no están asignados.");
        }
    }
}
*/



public class EnemyShoot : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform firePoint; // Punto desde donde se disparan los proyectiles
    public float fireRate = 2f; // Tasa de disparo en segundos
    private float nextFireTime = 0f;
    public Vector3 targetDirection = Vector3.right; // Dirección fija de disparo (eje X positivo)

    void Update()
    {
        if (Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
            Projectile projectileComponent = projectile.GetComponent<Projectile>();
            if (projectileComponent != null)
            {
                projectileComponent.SetDirection(targetDirection);
            }
            else
            {
                Debug.LogWarning("El prefab del proyectil no tiene un componente Projectile.");
            }
        }
        else
        {
            Debug.LogWarning("El prefab del proyectil o el firePoint no están asignados.");
        }
    }
}
