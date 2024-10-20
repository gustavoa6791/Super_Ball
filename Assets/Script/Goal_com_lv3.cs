using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_com_lv3 : MonoBehaviour
{
    // Este método se llama cuando el objeto entra en el área de colisión (trigger)
    private void OnTriggerEnter(Collider other)
    {
        // Verificamos si el objeto que colisionó tiene el tag "Bola"
        if (other.CompareTag("BALL"))
        {
            // Mostramos el mensaje de gol en la consola
            Debug.Log("Se anotó un gol");
        }
    }
}
