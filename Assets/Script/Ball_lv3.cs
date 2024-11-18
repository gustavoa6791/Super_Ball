using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball_lv3 : MonoBehaviour
{
    public GameObject goalPlayer;
    public GameObject goalCom;
    public Text goalPlayerHitText;
    public Text goalComHitText;
    public Text endGameText;
    public Button continueButton;
    public Button changeSceneButton;
    public Button restartSceneButton;
    public Button menuSceneButton;
    public Canvas canvas;
    public int nextSceneNumber;

    private static int goalPlayerHitCount = 0;
    private static int goalComHitCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Aseguramos que el juego comience en tiempo normal
        //Time.timeScale = 1f;

        // Ocultamos el Canvas al inicio
        canvas.gameObject.SetActive(false);
        endGameText.gameObject.SetActive(false);
        changeSceneButton.gameObject.SetActive(false);

        // Configuración inicial de la velocidad de la bola
        float[] initial = { -5f, 5f };
        int Xrandom = (int)Random.Range(0, 1.9f);
        int Yrandom = (int)Random.Range(0, 1.9f);
        GetComponent<Rigidbody>().velocity = new Vector3(initial[Xrandom], 0, initial[Yrandom]);

        // Asignamos las funciones a los botones
        continueButton.onClick.AddListener(ResumeGame);
        changeSceneButton.onClick.AddListener(ChangeScene);
        restartSceneButton.onClick.AddListener(RestartScene);
        menuSceneButton.onClick.AddListener(MenuScene);
    }

    // Se ejecuta cuando la bola colisiona con otro objeto
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == goalPlayer)
        {
            goalPlayerHitCount++;
            Debug.Log("Goal_Player ha sido golpeado " + goalPlayerHitCount + " veces.");

            // Actualiza el texto y muestra el Canvas
            ShowCanvas();
            goalComHitText.text = "Goles del Jugador: " + goalComHitCount;
            goalPlayerHitText.text = "Goles del Enemigo: " + goalPlayerHitCount;

            CheckGameOver();
        }
        else if (collision.gameObject == goalCom)
        {
            goalComHitCount++;
            Debug.Log("Goal_Com ha sido golpeado " + goalComHitCount + " veces.");

            // Actualiza el texto y muestra el Canvas
            ShowCanvas();
            goalComHitText.text = "Goles del Jugador: " + goalComHitCount;
            goalPlayerHitText.text = "Goles del Enemigo: " + goalPlayerHitCount;

            CheckGameOver();
        }
    }

    // Muestra el Canvas y pausa el juego
    void ShowCanvas()
    {
        canvas.gameObject.SetActive(true);
        Time.timeScale = 0; // Pausa el juego
    }

    // Verifica si el juego ha terminado
    void CheckGameOver()
    {
        if (goalPlayerHitCount >= 3 || goalComHitCount >= 3)
        {
            endGameText.gameObject.SetActive(true);
            endGameText.text = (goalPlayerHitCount >= 3) ? "¡El Enemigo ha ganado!" : "¡El Jugador ha ganado!";

            // Muestra el botón para cambiar de escena y oculta otros elementos
            changeSceneButton.gameObject.SetActive(true);
            goalPlayerHitText.gameObject.SetActive(false);
            goalComHitText.gameObject.SetActive(false);
            continueButton.gameObject.SetActive(false);
        }
    }

    // Reanuda el juego y reinicia los contadores
    void ResumeGame()
    {
        // Oculta el Canvas
        canvas.gameObject.SetActive(false);

        // Reinicia el juego
        //goalPlayerHitCount = 0;
        //goalComHitCount = 0;
        Time.timeScale = 1;

        // Reinicia la escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Cambia a la siguiente escena
    void ChangeScene()
    {
        // Oculta el Canvas y reanuda el tiempo antes de cambiar de escena
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        // Reinicia el juego
        goalPlayerHitCount = 0;
        goalComHitCount = 0;

        // Cambia a la escena especificada
        SceneManager.LoadScene(nextSceneNumber);
    }

    // Reiniciar escena
    void RestartScene()
    {
        // Oculta el Canvas
        canvas.gameObject.SetActive(false);

        // Reinicia el juego
        goalPlayerHitCount = 0;
        goalComHitCount = 0;
        Time.timeScale = 1;

        // Reinicia la escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Reiniciar escena
    void MenuScene()
    {
        // Oculta el Canvas
        canvas.gameObject.SetActive(false);

        // Reinicia el juego
        goalPlayerHitCount = 0;
        goalComHitCount = 0;
        Time.timeScale = 1;

        // Reinicia la escena
        SceneManager.LoadScene("Menu");
    }
}
