using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Para manejar la UI
using UnityEngine.SceneManagement; // Para cambiar de escena

public class Ball_lv3 : MonoBehaviour
{
    public GameObject goalPlayer; // Asigna el objeto Goal_Player desde el editor
    public GameObject goalCom; // Asigna el objeto Goal_Com desde el editor
    public Text goalPlayerHitText; // Asigna el componente Text para el Goal_Player desde el Canvas
    public Text goalComHitText; // Asigna el componente Text para el Goal_Com desde el Canvas
    public Text endGameText; // Asigna el componente Text para mostrar el resultado final
    public Button continueButton; // Asigna el componente Button para reanudar el juego
    public Button changeSceneButton; // Asigna el componente Button para cambiar de escena
    public Canvas canvas; // Asigna el Canvas desde el editor
    public int nextSceneNumber;

    private static int goalPlayerHitCount = 0; // Contador de golpes al Goal_Player
    private static int goalComHitCount = 0; // Contador de golpes al Goal_Com

    // Start is called before the first frame update
    void Start()
    {
        // Ocultamos el Canvas al inicio
        canvas.gameObject.SetActive(false);
        endGameText.gameObject.SetActive(false); // Oculta el texto del final
        changeSceneButton.gameObject.SetActive(false); // Oculta el botón para cambiar de escena


        float[] initial = { -5f, 5f };
        int Xrandom = (int)Random.Range(0, 1.9f);
        int Yrandom = (int)Random.Range(0, 1.9f);
        GetComponent<Rigidbody>().velocity = new Vector3(initial[Xrandom], 0, initial[Yrandom]);

        // Asignamos la función al botón para que oculte el Canvas y reanude el juego
        continueButton.onClick.AddListener(ResumeGame);
        changeSceneButton.onClick.AddListener(ChangeScene);
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
            ShowCanvas();
            goalComHitText.text = "Goles del Jugador: " + goalComHitCount; // se refiere a que el enemigo a sido golpeado por el jugador
            goalPlayerHitText.text = "Goles del Enemigo: " + goalPlayerHitCount; // se refiere a que el jugador a sido golpeado por el enemigo

            CheckGameOver();
        }
        // Verifica si colisionó con Goal_Com
        else if (collision.gameObject == goalCom)
        {
            goalComHitCount++; // Aumenta el contador
            Debug.Log("Goal_Com ha sido golpeado " + goalComHitCount + " veces."); // Muestra en consola

            // Mostrar el Canvas, actualizar el texto de Goal_Com y pausar el juego
            ShowCanvas();
            goalComHitText.text = "Goles del Jugador: " + goalComHitCount; // se refiere a que el enemigo a sido golpeado por el jugador
            goalPlayerHitText.text = "Goles del Enemigo: " + goalPlayerHitCount; // se refiere a que el jugador a sido golpeado por el enemigo

            CheckGameOver();
        }
    }

    // Función para mostrar el Canvas y pausar el juego
    void ShowCanvas()
    {
        canvas.gameObject.SetActive(true);
        Time.timeScale = 0; // Pausar el juego
    }

    // Verifica si alguno de los contadores ha llegado a 3
    void CheckGameOver()
    {
        if (goalPlayerHitCount >= 3 || goalComHitCount >= 3)
        {
            // Mostrar el mensaje de fin de juego
            endGameText.gameObject.SetActive(true);
            endGameText.text = (goalPlayerHitCount >= 3) ?
                "¡El Enemigo ha ganado!":"¡El Jugador ha ganado!";

            // Mostrar el botón para cambiar de escena
            changeSceneButton.gameObject.SetActive(true);
            // Oculta los textos de count y le boton de continuar
            goalPlayerHitText.gameObject.SetActive(false); // Oculta el texto del final
            goalComHitText.gameObject.SetActive(false); // Oculta el texto del final
            continueButton.gameObject.SetActive(false); // Oculta el botón para cambiar de escena
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

    // Función para cambiar de escena
    void ChangeScene()
    {
        // Ocultar el Canvas
        canvas.gameObject.SetActive(false);

        // Reanudar el juego
        Time.timeScale = 1;

        // Cambia a la escena deseada (cambia "NombreDeLaEscena" por el nombre de la escena a la que deseas ir)
        SceneManager.LoadScene(nextSceneNumber);
    }
}
