using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Llave : MonoBehaviour
{
    private Receptor receptorActual; // El receptor actual donde se colocó la llave

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Recibidor"))
        {
            receptorActual = other.GetComponent<Receptor>(); // Obtener el script Receptor del objeto
            if (receptorActual != null)
            {
                receptorActual.ColocarLlave(this.gameObject); // Llamar al método para colocar la llave en el receptor
                gameObject.SetActive(false); // Desactivar la llave para que "desaparezca"
            }
        }
    }

    public void ActivarLlave()
    {
        gameObject.SetActive(true); // Activar la llave cuando se recoja nuevamente
    }
}
