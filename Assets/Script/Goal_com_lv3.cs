using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_com_lv3 : MonoBehaviour
{
    // Este m�todo se llama cuando el objeto entra en el �rea de colisi�n (trigger)
    private void OnTriggerEnter(Collider other)
    {
        // Verificamos si el objeto que colision� tiene el tag "Bola"
        if (other.CompareTag("BALL"))
        {
            // Mostramos el mensaje de gol en la consola
            Debug.Log("Se anot� un gol");
        }
    }
}
