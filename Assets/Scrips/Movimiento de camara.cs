
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientodecamara : MonoBehaviour
{
    public Transform jugador; // Referencia al transform del jugador
    public Vector3 offset; // Desplazamiento entre la cámara y el jugador
    public float velocidadSuavizado = 0.125f; // Velocidad del suavizado
    public float sensibilidadMouse = 100.0f; // Sensibilidad del ratón

    private float rotacionX = 0.0f;
    private float rotacionY = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Ocultar y bloquear el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Rotación de la cámara con el ratón
        rotacionX -= Input.GetAxis("Mouse Y") * sensibilidadMouse * Time.deltaTime;
        rotacionY += Input.GetAxis("Mouse X") * sensibilidadMouse * Time.deltaTime;

        // Limitar la rotación en el eje X
        rotacionX = Mathf.Clamp(rotacionX, -90.0f, 90.0f);

        // Calcula la rotación en el eje Y en función del jugador y el ratón
        Quaternion rotacionDeseada = Quaternion.Euler(rotacionX, rotacionY, 0.0f);

        // Aplica la rotación a la cámara
        transform.position = jugador.position - (rotacionDeseada * offset);
        transform.LookAt(jugador);

        // Suavizar el movimiento de la cámara
        Vector3 posicionSuavizada = Vector3.Lerp(transform.position, jugador.position - (rotacionDeseada * offset), velocidadSuavizado);

        // Asignar la posición suavizada a la cámara
        transform.position = posicionSuavizada;
    }
}
