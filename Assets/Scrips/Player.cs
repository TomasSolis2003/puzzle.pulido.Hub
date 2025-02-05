
/*using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform handTransform; // La posici�n donde el objeto se colocar� cuando sea recogido
    public float pickUpRange = 3.0f; // La distancia m�xima a la que el jugador puede recoger objetos
    public LayerMask pickUpLayer; // La capa en la que se encuentran los objetos que se pueden recoger

    private GameObject heldObject = null;
    private Rigidbody heldObjectRb = null;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null)
            {
                TryPickUpObject();
            }
            else
            {
                DropObject();
            }
        }

        if (heldObject != null)
        {
            heldObject.transform.position = handTransform.position;
            heldObject.transform.rotation = handTransform.rotation;
        }
    }

    void TryPickUpObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, pickUpRange, pickUpLayer))
        {
            if (hit.collider.CompareTag("Llave"))
            {
                heldObject = hit.collider.gameObject;
                heldObjectRb = heldObject.GetComponent<Rigidbody>();
                if (heldObjectRb != null)
                {
                    heldObjectRb.isKinematic = true; // Desactivar la f�sica mientras se sostiene
                }
                heldObject.transform.SetParent(handTransform); // Hacer que la bater�a sea hijo de la mano
                Debug.Log("Objeto recogido.");
            }
        }
    }

    void DropObject()
    {
        if (heldObject != null)
        {
            heldObject.transform.SetParent(null); // Desvincular la bater�a de la mano
            if (heldObjectRb != null)
            {
                heldObjectRb.isKinematic = false; // Reactivar la f�sica
            }
            heldObject = null;
            heldObjectRb = null;
            Debug.Log("Objeto soltado.");
        }
    }
}
*/
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform handTransform; // La posici�n donde el objeto se colocar� cuando sea recogido
    public float pickUpRange = 3.0f; // La distancia m�xima a la que el jugador puede recoger objetos
    public LayerMask pickUpLayer; // La capa en la que se encuentran los objetos que se pueden recoger
    public int saludMaxima = 200; // Puntos m�ximos de salud del jugador

    private int saludActual; // Puntos de salud actuales del jugador
    private GameObject heldObject = null;
    private Rigidbody heldObjectRb = null;

    void Start()
    {
        saludActual = saludMaxima; // Inicializar la salud actual al m�ximo al inicio del juego
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null)
            {
                TryPickUpObject();
            }
            else
            {
                DropObject();
            }
        }

        if (heldObject != null)
        {
            heldObject.transform.position = handTransform.position;
            heldObject.transform.rotation = handTransform.rotation;
        }
    }

    void TryPickUpObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, pickUpRange, pickUpLayer))
        {
            if (hit.collider.CompareTag("Llave"))
            {
                heldObject = hit.collider.gameObject;
                heldObjectRb = heldObject.GetComponent<Rigidbody>();
                if (heldObjectRb != null)
                {
                    heldObjectRb.isKinematic = true; // Desactivar la f�sica mientras se sostiene
                }
                heldObject.transform.SetParent(handTransform); // Hacer que la bater�a sea hijo de la mano
                Debug.Log("Objeto recogido.");
            }
        }
    }

    void DropObject()
    {
        if (heldObject != null)
        {
            heldObject.transform.SetParent(null); // Desvincular la bater�a de la mano
            if (heldObjectRb != null)
            {
                heldObjectRb.isKinematic = false; // Reactivar la f�sica
            }
            heldObject = null;
            heldObjectRb = null;
            Debug.Log("Objeto soltado.");
        }
    }

    public void RecibirDanio(int cantidadDanio)
    {
        saludActual -= cantidadDanio;

        if (saludActual <= 0)
        {
            saludActual = 0;
            // Aqu� puedes a�adir la l�gica para cuando el jugador muera
            Debug.Log("El jugador ha muerto.");
        }

        Debug.Log("Salud actual del jugador: " + saludActual);
    }

    public void Curar(int cantidadCuracion)
    {
        saludActual += cantidadCuracion;

        if (saludActual > saludMaxima)
        {
            saludActual = saludMaxima;
        }

        Debug.Log("Salud actual del jugador: " + saludActual);
    }
}
