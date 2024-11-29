using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_collision : MonoBehaviour
{
    // Contador de colisiones
    private int collisionCount = 0;

    // Variable p�blica para establecer el color desde el inspector
    public Color collisionColor = Color.red;

    // Referencia al Renderer del bloque
    private Renderer blockRenderer;

    // M�todo que se llama al comenzar
    void Start()
    {
        // Obt�n el componente Renderer del bloque
        blockRenderer = GetComponent<Renderer>();
    }

    // M�todo que se llama cuando algo colisiona con el bloque
    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto que colisiona es la bola (usando el tag "BALL")
        if (collision.gameObject.CompareTag("BALL"))
        {
            collisionCount++; // Incrementa el contador de colisiones

            // Si es la primera colisi�n, cambia el color al definido en la variable
            if (collisionCount == 1)
            {
                blockRenderer.material.color = collisionColor; // Cambia el color
            }

            // Si es la segunda colisi�n, destruye el bloque
            if (collisionCount == 2)
            {
                Destroy(gameObject); // Destruye el bloque
            }
        }
    }
}
