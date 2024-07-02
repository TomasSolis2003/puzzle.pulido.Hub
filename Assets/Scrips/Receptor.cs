using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Receptor : MonoBehaviour
{
    public Puerta puerta; // Referencia al script Puerta asociado al GameObject de la puerta
    private GameObject llaveActual; // Llave actual colocada en el receptor

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && llaveActual != null)
        {
            QuitarLlave();
        }
    }

    public void ColocarLlave(GameObject llave)
    {
        if (llaveActual == null)
        {
            llaveActual = llave;
            puerta.Abrir(); // Abrir la puerta al colocar la llave en el receptor
        }
    }

    public void QuitarLlave()
    {
        if (llaveActual != null)
        {
            llaveActual.GetComponent<Llave>().ActivarLlave(); // Activar la llave para que pueda ser recogida de nuevo
            llaveActual = null;
            puerta.Cerrar(); // Cerrar la puerta al quitar la llave del receptor
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Llave") && llaveActual == null)
        {
            other.gameObject.SetActive(false); // Desactivar la llave para que "desaparezca"
            llaveActual = other.gameObject;
            puerta.Abrir(); // Abrir la puerta al colocar la llave en el receptor
        }
    }

    public bool TieneLlave()
    {
        return llaveActual != null;
    }
}
