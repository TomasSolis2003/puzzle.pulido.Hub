using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGameNamespace
{
    public class ArmaMataJefe : MonoBehaviour
    {
        public int daño = 30; // Daño del arma
        public GameObject balaPrefab; // Prefab de la bala
        public Transform puntoDisparo; // Punto desde donde se dispara la bala
        public float velocidadBala = 20f; // Velocidad de la bala

        void Update()
        {
            if (Input.GetMouseButtonDown(1)) // Click derecho
            {
                Disparar();
            }
        }

        /*void Disparar()
        {
            GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);
            BalaMataJefe scriptBala = bala.GetComponent<BalaMataJefe>();
            scriptBala.daño = daño;
            scriptBala.velocidad = velocidadBala;
        }*/
        void Disparar()
        {
            // Verifica si balaPrefab está asignado antes de intentar instanciar
            if (balaPrefab == null)
            {
                Debug.LogError("¡No se ha asignado un prefab de bala en el Inspector de Unity!");
                return; // Sale del método si no hay prefab de bala asignado
            }

            GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);
            BalaMataJefe scriptBala = bala.GetComponent<BalaMataJefe>();

            if (scriptBala != null)
            {
                scriptBala.daño = daño;
                scriptBala.velocidad = velocidadBala;
            }
            else
            {
                Debug.LogError("El prefab de la bala no tiene el componente BalaMataJefe adjunto.");
            }
        }

    }
}
