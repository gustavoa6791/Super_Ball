using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    public float speed = 3f;           // Velocidad de movimiento
    public float distance = 5f;        // Distancia que se moverá de un lado a otro
    public float moveLeft = 0f;        // Determina la dirección del movimiento (1 para derecha, -1 para izquierda)
    private Vector3 startPos;          // Posición inicial de la pared

    void Start()
    {
        startPos = transform.position;  // Guardar la posición inicial
    }

    void Update()
    {
        // Calcular el movimiento usando PingPong
        float movement = Mathf.PingPong(Time.time * speed, distance);
        
        // Ajusta el movimiento en el eje deseado (en este caso, en X)
        transform.position = startPos + new Vector3(movement * moveLeft, 0, 0);
    }
}
