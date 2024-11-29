using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Contador de colisiones
    private int collisionCount = 0;

    // Variable pública para establecer el color desde el inspector
    public Color collisionColor = Color.red;

    // Referencia al Renderer del bloque
    private Renderer blockRenderer;

    // Método que se llama al comenzar
    void Start()
    {
        // Obtén el componente Renderer del bloque
        blockRenderer = GetComponent<Renderer>();
    }

    // Método que se llama cuando algo colisiona con la moneda
    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto que colisiona es la bola (usando el tag "Ball")
        if (collision.gameObject.CompareTag("BALL"))
        {
            collisionCount++; // Incrementa el contador de colisiones

            // Si es la primera colisión, cambia el color al definido en la variable
            if (collisionCount == 1)
            {
                blockRenderer.material.color = collisionColor; // Cambia el color
            }

            // Si es la segunda colisión, destruye la moneda
            if (collisionCount == 2)
            {
                // Destruir la moneda después de recogerla
                Destroy(gameObject); 
            }
        }
    }
}
