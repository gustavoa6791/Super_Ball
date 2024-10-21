using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Para manejar la UI
using UnityEngine.SceneManagement; // Para reiniciar la escena

public class Ball_lv3 : MonoBehaviour
{
    public GameObject goalPlayer; // Asigna el objeto Goal_Player desde el editor
    public GameObject goalCom; // Asigna el objeto Goal_Com desde el editor
    public Text goalPlayerHitText; // Asigna el componente Text para el Goal_Player desde el Canvas
    public Text goalComHitText; // Asigna el componente Text para el Goal_Com desde el Canvas
    public Button continueButton; // Asigna el componente Button desde el Canvas
    public Canvas canvas; // Asigna el Canvas desde el editor

    private static int goalPlayerHitCount = 0; // Contador de golpes al Goal_Player
    private static int goalComHitCount = 0; // Contador de golpes al Goal_Com

    // Start is called before the first frame update
    void Start()
    {
        // Ocultamos el Canvas al inicio
        canvas.gameObject.SetActive(false);

        float[] initial = { -5f, 5f };
        int Xrandom = (int)Random.Range(0, 1.9f);
        int Yrandom = (int)Random.Range(0, 1.9f);
        GetComponent<Rigidbody>().velocity = new Vector3(initial[Xrandom], 0, initial[Yrandom]);

        // Asignamos la función al botón para que oculte el Canvas y reanude el juego
        continueButton.onClick.AddListener(ResumeGame);
    }

    // Se ejecuta cuando la bola colisiona con otro objeto
    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si colisionó con Goal_Player
        if (collision.gameObject == goalPlayer)
        {
            goalPlayerHitCount++; // Aumenta el contador
            Debug.Log("Goal_Player ha sido golpeado " + goalPlayerHitCount + " veces."); // Muestra en consola

            // Mostrar el Canvas, actualizar el texto de Goal_Player y pausar el juego
            canvas.gameObject.SetActive(true);
            goalComHitText.text = "Goles del Jugador: " + goalComHitCount; // se refiere a que el enemigo a sido golpeado por el jugador
            goalPlayerHitText.text = "Goles del Enemigo: " + goalPlayerHitCount; // se refiere a que el jugador a sido golpeado por el enemigo
            
            Time.timeScale = 0; // Pausar el juego
        }
        // Verifica si colisionó con Goal_Com
        else if (collision.gameObject == goalCom)
        {
            goalComHitCount++; // Aumenta el contador
            Debug.Log("Goal_Com ha sido golpeado " + goalComHitCount + " veces."); // Muestra en consola

            // Mostrar el Canvas, actualizar el texto de Goal_Com y pausar el juego
            canvas.gameObject.SetActive(true);
            goalComHitText.text = "Goles del Jugador: " + goalComHitCount; // se refiere a que el enemigo a sido golpeado por el jugador
            goalPlayerHitText.text = "Goles del Enemigo: " + goalPlayerHitCount; // se refiere a que el jugador a sido golpeado por el enemigo

            Time.timeScale = 0; // Pausar el juego
        }
    }

    // Función para ocultar el Canvas y reanudar el juego
    void ResumeGame()
    {
        // Ocultar el Canvas
        canvas.gameObject.SetActive(false);

        // Reanudar el juego
        Time.timeScale = 1;

        // Reinicia la escena sin reiniciar los contadores
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
