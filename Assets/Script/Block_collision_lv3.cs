using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_collision : MonoBehaviour
{
    // Contador de colisiones
    private int collisionCount = 0;

    // M�todo que se llama cuando algo colisiona con el bloque
    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto que colisiona es la bola (usando el tag "Ball")
        if (collision.gameObject.CompareTag("BALL"))
        {
            collisionCount++; // Incrementa el contador de colisiones

            // Si es la segunda colisi�n, destruye el bloque
            if (collisionCount == 2)
            {
                Destroy(gameObject); // Destruye el bloque
            }
        }
    }
}
