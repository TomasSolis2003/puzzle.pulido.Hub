
/*using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Transform handTransform; // La posici�n donde el objeto se colocar� cuando sea recogido
    public Camera playerCamera; // La c�mara del jugador
    public float pickUpRange = 3.0f; // La distancia m�xima a la que el jugador puede recoger objetos
    public LayerMask pickUpLayer; // La capa en la que se encuentran los objetos que se pueden recoger
    public float throwForce = 10.0f; // La fuerza con la que se lanzar�n los objetos

    private GameObject heldObject = null;
    private Rigidbody heldObjectRb = null;

    void Update()
    {
        UpdateHandPosition();

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

        if (Input.GetKeyDown(KeyCode.F) && heldObject != null)
        {
            ThrowObject();
        }

        if (heldObject != null)
        {
            heldObject.transform.position = handTransform.position;
            heldObject.transform.rotation = handTransform.rotation;
        }
    }

    void UpdateHandPosition()
    {
        handTransform.position = playerCamera.transform.position + playerCamera.transform.forward * 1.5f; // Ajusta la distancia seg�n sea necesario
        handTransform.rotation = playerCamera.transform.rotation;
    }

    void TryPickUpObject()
    {
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
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
                    heldObjectRb.detectCollisions = false; // Desactivar las colisiones mientras se sostiene
                }
                Debug.Log("Objeto recogido.");
            }
        }
    }

    void DropObject()
    {
        if (heldObject != null)
        {
            if (heldObjectRb != null)
            {
                heldObjectRb.isKinematic = false; // Reactivar la f�sica
                heldObjectRb.detectCollisions = true; // Reactivar las colisiones
            }
            heldObject = null;
            heldObjectRb = null;
            Debug.Log("Objeto soltado.");
        }
    }

    void ThrowObject()
    {
        if (heldObject != null)
        {
            if (heldObjectRb != null)
            {
                heldObjectRb.isKinematic = false; // Reactivar la f�sica
                heldObjectRb.detectCollisions = true; // Reactivar las colisiones
                heldObjectRb.AddForce(playerCamera.transform.forward * throwForce, ForceMode.VelocityChange); // Aplicar fuerza para lanzar el objeto
            }
            heldObject = null;
            heldObjectRb = null;
            Debug.Log("Objeto lanzado.");
        }
    }
}
*/
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Transform handTransform; // La posici�n donde el objeto se colocar� cuando sea recogido
    public Camera playerCamera; // La c�mara del jugador
    public float pickUpRange = 3.0f; // La distancia m�xima a la que el jugador puede recoger objetos
    public LayerMask pickUpLayer; // La capa en la que se encuentran los objetos que se pueden recoger
    public float throwForce = 10.0f; // La fuerza con la que se lanzar�n los objetos

    private GameObject heldObject = null;
    private Rigidbody heldObjectRb = null;

    void Update()
    {
        UpdateHandPosition();

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

        if (Input.GetKeyDown(KeyCode.F) && heldObject != null)
        {
            ThrowObject();
        }

        if (heldObject != null)
        {
            heldObject.transform.position = handTransform.position;
            heldObject.transform.rotation = handTransform.rotation;
        }
    }

    void UpdateHandPosition()
    {
        handTransform.position = playerCamera.transform.position + playerCamera.transform.forward * 1.5f; // Ajusta la distancia seg�n sea necesario
        handTransform.rotation = playerCamera.transform.rotation;
    }

    void TryPickUpObject()
    {
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, pickUpRange, pickUpLayer))
        {
            if (hit.collider.CompareTag("Llave") || hit.collider.CompareTag("CAJA"))
            {
                heldObject = hit.collider.gameObject;
                heldObjectRb = heldObject.GetComponent<Rigidbody>();
                if (heldObjectRb != null)
                {
                    heldObjectRb.isKinematic = true; // Desactivar la f�sica mientras se sostiene
                    heldObjectRb.detectCollisions = false; // Desactivar las colisiones mientras se sostiene
                }
                Debug.Log("Objeto recogido: " + heldObject.name);
            }
        }
    }

    void DropObject()
    {
        if (heldObject != null)
        {
            if (heldObjectRb != null)
            {
                heldObjectRb.isKinematic = false; // Reactivar la f�sica
                heldObjectRb.detectCollisions = true; // Reactivar las colisiones
            }
            heldObject = null;
            heldObjectRb = null;
            Debug.Log("Objeto soltado.");
        }
    }

    void ThrowObject()
    {
        if (heldObject != null)
        {
            if (heldObjectRb != null)
            {
                heldObjectRb.isKinematic = false; // Reactivar la f�sica
                heldObjectRb.detectCollisions = true; // Reactivar las colisiones
                heldObjectRb.AddForce(playerCamera.transform.forward * throwForce, ForceMode.VelocityChange); // Aplicar fuerza para lanzar el objeto
            }
            heldObject = null;
            heldObjectRb = null;
            Debug.Log("Objeto lanzado.");
        }
    }
}
