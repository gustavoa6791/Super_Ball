using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oponent_lv3 : MonoBehaviour
{
    public float SPEED = 1.5f;
    public float FORCE = 10f;
    public float ROTATION = 1f;
    public float detectionRadius = 5f; // Radio de detecci�n
    public Transform ball; // Referencia a la pelota
    public Transform goalPlayer; // Referencia a la porter�a del jugador
    public Vector3 initialPosition; // Posici�n inicial del oponente
    public float stopThreshold = 0.1f; // Umbral para considerar que ha llegado a la posici�n inicial

    private Vector3 movementDirection;
    public Animator animator;

    void Start()
    {
        // Guardar la posici�n inicial del oponente
        initialPosition = transform.position;
    }

    private void FixedUpdate()
    {
        Vector3 directionToBall = ball.position - transform.position;
        directionToBall.y = 0; // Ignorar la componente Y para evitar rotaci�n vertical

        // Verificar si la pelota est� dentro del radio de detecci�n
        if (Vector3.Distance(transform.position, ball.position) <= detectionRadius)
        {
            // Moverse hacia la pelota
            MoveTowards(ball.position, true);
        }
        else
        {
            // Regresar a la posici�n inicial
            MoveTowards(initialPosition, false);
        }
    }

    private void MoveTowards(Vector3 targetPosition, bool isChasingBall)
    {
        // Calcular la direcci�n hacia el objetivo
        Vector3 direction = targetPosition - transform.position;

        // Si est� regresando a la posici�n inicial y ya lleg�, detener animaci�n
        if (!isChasingBall && Vector3.Distance(transform.position, initialPosition) <= stopThreshold)
        {
            animator.SetFloat("MOVE", 0); // Detener animaciones
            return; // Salir sin mover
        }

        // Mover hacia el objetivo
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, SPEED * Time.deltaTime);

        // Rotar hacia el objetivo si se est� moviendo
        if (direction.magnitude > 0.02f)
        {
            animator.SetFloat("MOVE", 1f, 0.1f, Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), ROTATION * Time.deltaTime);
        }
        else
        {
            animator.SetFloat("MOVE", 0, 0.1f, Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si el objeto que toca es la pelota
        if (other.CompareTag("BALL"))
        {
            Vector3 goalDirection = (goalPlayer.position - transform.position).normalized;

            // Orientar al personaje hacia la porter�a antes de golpear
            transform.rotation = Quaternion.LookRotation(goalDirection);

            // Golpear la pelota en la direcci�n de la porter�a
            other.GetComponent<Rigidbody>().velocity = goalDirection * FORCE;
        }
    }
}
