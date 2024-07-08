using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*namespace MyGameNamespace
{
    public class BalaMataJefe : MonoBehaviour
    {
        public int daño = 30;
        public float velocidad = 20f; // Velocidad de la bala

        void Start()
        {
            // Asegurarse de que la bala se mueva en la dirección en la que fue disparada
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.useGravity = false; // Desactivar la gravedad
            rb.velocity = transform.forward * velocidad;
        }

        void OnTriggerEnter(Collider otro)
        {
            if (otro.CompareTag("Jefe"))
            {
                JefeComportamiento jefe = otro.GetComponent<JefeComportamiento>();
                if (jefe != null)
                {
                    jefe.RecibirDaño(daño);
                }
                Destroy(gameObject);
            }
        }
    }
}
*/


namespace MyGameNamespace
{
    public class BalaMataJefe : MonoBehaviour
    {
        public int daño = 30;
        public float velocidad = 20f; // Velocidad de la bala
        public float tiempoVida = 10f; // Tiempo de vida de la bala en segundos

        void Start()
        {
            // Asegurarse de que la bala se mueva en la dirección en la que fue disparada
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.useGravity = false; // Desactivar la gravedad
            rb.velocity = transform.forward * velocidad;

            // Destruir la bala después de cierto tiempo
            Destroy(gameObject, tiempoVida);
        }

        void OnTriggerEnter(Collider otro)
        {
            if (otro.CompareTag("Jefe"))
            {
                JefeComportamiento jefe = otro.GetComponent<JefeComportamiento>();
                if (jefe != null)
                {
                    jefe.RecibirDaño(daño);
                }
                // Destruir la bala al colisionar con el jefe
                Destroy(gameObject);
            }
        }
    }
}
