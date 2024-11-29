using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oponent_lv3 : MonoBehaviour
{
    public float SPEED = 1.5f;
    public float FORCE = 10f;
    public float ROTATION = 1f;
    public float detectionRadius = 5f; // Radio de detección
    public Transform ball; // Referencia a la pelota
    public Transform goalPlayer; // Referencia a la portería del jugador
    public Vector3 initialPosition; // Posición inicial del oponente
    public float stopThreshold = 0.1f; // Umbral para considerar que ha llegado a la posición inicial

    private Vector3 movementDirection;
    public Animator animator;

    void Start()
    {
        // Guardar la posición inicial del oponente
        initialPosition = transform.position;
    }

    private void FixedUpdate()
    {
        Vector3 directionToBall = ball.position - transform.position;
        directionToBall.y = 0; // Ignorar la componente Y para evitar rotación vertical

        // Verificar si la pelota está dentro del radio de detección
        if (Vector3.Distance(transform.position, ball.position) <= detectionRadius)
        {
            // Moverse hacia la pelota
            MoveTowards(ball.position, true);
        }
        else
        {
            // Regresar a la posición inicial
            MoveTowards(initialPosition, false);
        }
    }

    private void MoveTowards(Vector3 targetPosition, bool isChasingBall)
    {
        // Calcular la dirección hacia el objetivo
        Vector3 direction = targetPosition - transform.position;

        // Si está regresando a la posición inicial y ya llegó, detener animación
        if (!isChasingBall && Vector3.Distance(transform.position, initialPosition) <= stopThreshold)
        {
            animator.SetFloat("MOVE", 0); // Detener animaciones
            return; // Salir sin mover
        }

        // Mover hacia el objetivo
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, SPEED * Time.deltaTime);

        // Rotar hacia el objetivo si se está moviendo
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

            // Orientar al personaje hacia la portería antes de golpear
            transform.rotation = Quaternion.LookRotation(goalDirection);

            // Golpear la pelota en la dirección de la portería
            other.GetComponent<Rigidbody>().velocity = goalDirection * FORCE;
        }
    }
}
