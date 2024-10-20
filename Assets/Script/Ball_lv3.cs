using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Necesario si usas UI como Panel o Texto
using UnityEngine.SceneManagement; // Para reiniciar el juego

public class Ball_lv3 : MonoBehaviour
{
    public GameObject golComPanel; // Panel UI que se mostrará cuando gol com
    public GameObject golPlayerPanel; // Panel UI que se mostrará cuando gol player
    public Text golComText;  // Texto para mostrar en el panel de gol com
    public Text golPlayerText; // Texto para mostrar en el panel de gol player
    public int golesCom = 0; // Contador de goles para com
    public int golesPlayer = 0; // Contador de goles para player
    public int maxGoles = 3; // Límite de goles para terminar el juego
    private bool juegoPausado = false; // Para verificar si el juego está pausado

    // Detectar colisiones
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BALL"))
        {
            if (gameObject.CompareTag("gol_com"))
            {
                golesPlayer++;
                MostrarMensajeGol("Anotaste un gol en gol_com");
                golComPanel.SetActive(true); // Mostrar panel para gol com
            }
            else if (gameObject.CompareTag("gol_player"))
            {
                golesCom++;
                MostrarMensajeGol("Anotaste un gol en gol_player");
                golPlayerPanel.SetActive(true); // Mostrar panel para gol player
            }
            PausarJuego();

            // Revisar si el juego ha terminado
            if (golesCom >= maxGoles || golesPlayer >= maxGoles)
            {
                TerminarJuego();
            }
        }
    }

    // Mostrar mensaje de gol y pausar el juego
    void MostrarMensajeGol(string mensaje)
    {
        Debug.Log(mensaje);
    }

    // Pausar el juego
    void PausarJuego()
    {
        juegoPausado = true;
        Time.timeScale = 0; // Pausar el tiempo
    }

    // Reanudar el juego
    public void ReanudarJuego()
    {
        juegoPausado = false;
        Time.timeScale = 1; // Reanudar el tiempo
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reiniciar la escena actual
    }

    // Terminar el juego
    void TerminarJuego()
    {
        if (golesCom >= maxGoles)
        {
            Debug.Log("Juego terminado, ¡ganó gol_com!");
        }
        else if (golesPlayer >= maxGoles)
        {
            Debug.Log("Juego terminado, ¡ganó gol_player!");
        }

        // Aquí podrías agregar una pantalla final para el juego o hacer lo que quieras al terminar.
    }
}
