
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform handTransform; // La posición donde el objeto se colocará cuando sea recogido
    public float pickUpRange = 3.0f; // La distancia máxima a la que el jugador puede recoger objetos
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
                    heldObjectRb.isKinematic = true; // Desactivar la física mientras se sostiene
                }
                heldObject.transform.SetParent(handTransform); // Hacer que la batería sea hijo de la mano
                Debug.Log("Objeto recogido.");
            }
        }
    }

    void DropObject()
    {
        if (heldObject != null)
        {
            heldObject.transform.SetParent(null); // Desvincular la batería de la mano
            if (heldObjectRb != null)
            {
                heldObjectRb.isKinematic = false; // Reactivar la física
            }
            heldObject = null;
            heldObjectRb = null;
            Debug.Log("Objeto soltado.");
        }
    }
}
