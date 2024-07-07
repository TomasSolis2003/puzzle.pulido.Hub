using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mantener el GameManager al cambiar de escena
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        // L�gica para manejar la p�rdida del juego
        Debug.Log("Game Over!");
        // Aqu� puedes agregar m�s l�gica, como mostrar una pantalla de fin de juego, reiniciar la escena, etc.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reiniciar la escena actual
    }
}
