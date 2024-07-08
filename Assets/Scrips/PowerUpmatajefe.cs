using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGameNamespace
{
    public class PowerUpMataJefe : MonoBehaviour
    {
        public GameObject armaPrefab; // Prefab del arma MataJefe

        void OnTriggerEnter(Collider otro)
        {
            if (otro.CompareTag("Player"))
            {
                // Añadir el arma al jugador
                otro.gameObject.AddComponent<ArmaMataJefe>();

                // Destruir el power-up
                Destroy(gameObject);
            }
        }
    }
}
