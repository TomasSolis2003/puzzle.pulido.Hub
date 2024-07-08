using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGameNamespace
{
    public class ShooterJugador : MonoBehaviour
    {
        // Otros componentes y variables del jugador

        void OnTriggerEnter(Collider otro)
        {
            if (otro.CompareTag("PowerUpMataJefe"))
            {
                // Añadir el arma MataJefe
                gameObject.AddComponent<ArmaMataJefe>().puntoDisparo = transform.Find("PuntoDisparo");

                // Destruir el power-up
                Destroy(otro.gameObject);
            }
        }
    }
}
