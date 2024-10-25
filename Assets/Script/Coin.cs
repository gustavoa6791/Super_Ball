using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Contador de colisiones
    private int collisionCount = 0;

    // Método que se llama cuando algo colisiona con la moneda
    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto que colisiona es la bola (usando el tag "Ball")
        if (collision.gameObject.CompareTag("BALL"))
        {
            collisionCount++; // Incrementa el contador de colisiones
            
            // Si es la segunda colisión, destruye la moneda
            if (collisionCount == 2)
            {
                // Destruir la moneda después de recogerla
                Destroy(gameObject); 
            }
        }
    }
}
