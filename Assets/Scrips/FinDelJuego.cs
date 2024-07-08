using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

/*public class FinalDelJuego : MonoBehaviour
{
    bool juegoPausado = false;

    void Update()
    {
        // Pausar el juego al recoger el objeto recogible
        if (Input.GetKeyDown(KeyCode.R))  // Cambia KeyCode.E por la tecla que desees para recoger el objeto
        {
            PausarJuego();
        }

        // Reanudar el juego al presionar la tecla "R"
        if (juegoPausado && Input.GetKeyDown(KeyCode.R))
        {
            ReiniciarJuego();
        }
    }

    void PausarJuego()
    {
        juegoPausado = true;
        Time.timeScale = 0f;  // Pausar el tiempo del juego
    }

    void ReiniciarJuego()
    {
        // Aquí reiniciamos el nivel actual
        Time.timeScale = 1f;  // Reanudar el tiempo del juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
*/


public class FinalDelJuego : MonoBehaviour
{
    bool juegoPausado = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PausarJuego();
        }
    }

    void Update()
    {
        if (juegoPausado && Input.GetKeyDown(KeyCode.R))
        {
            ReiniciarJuego();
        }
    }

    void PausarJuego()
    {
        juegoPausado = true;
        Time.timeScale = 0f;  // Pausar el tiempo del juego
    }

    void ReiniciarJuego()
    {
        // Aquí puedes reiniciar cualquier estado necesario antes de cargar la escena
        Time.timeScale = 1f;  // Reanudar el tiempo del juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
