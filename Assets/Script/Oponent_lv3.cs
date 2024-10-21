using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oponent_lv3 : MonoBehaviour
{
    public float SPEED = 1.5f;
    public float FORCE = 10f;
    public float ROTATION = 1f;
    public Transform ball; // Referencia a la pelota
    public Transform goalPlayer; // Referencia a la portería del jugador

    private Vector3 movementDirection;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializar variables, si es necesario
    }

    // Update is called once per frame
    void Update()
    {
        // Lógica de actualización, si es necesario
    }

    private void FixedUpdate()
    {
        // Siempre se dirige hacia la posición de la pelota
        Vector3 targetPosition = ball.position;

        // Calcular la dirección hacia la pelota
        Vector3 directionToBall = targetPosition - transform.position;
        directionToBall.y = 0; // Ignorar la componente Y para evitar rotación vertical

        // Solo mover si la pelota está en el campo del oponente
        if (ball.position.z <= 0)
        {
            // Si la pelota está en su campo, moverse hacia el centro
            transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.back, SPEED * Time.deltaTime);
        }
        else
        {
            // Moverse hacia la pelota
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, SPEED * Time.deltaTime);
        }

        // Calcular si se está moviendo
        if (directionToBall.magnitude > 0.02f)
        {
            animator.SetFloat("MOVE", 1f, 0.1f, Time.deltaTime);

            // Rotar hacia la pelota
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(directionToBall), ROTATION * Time.deltaTime);
        }
        else
        {
            animator.SetFloat("MOVE", 0, 0.1f, Time.deltaTime);
            // Mantener mirando hacia adelante cuando no se mueve
            transform.rotation = Quaternion.LookRotation(Vector3.forward);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si el objeto que toca es la pelota
        if (other.CompareTag("BALL"))
        {
            // Calcular la dirección hacia la portería del jugador
            Vector3 goalDirection = (goalPlayer.position - transform.position).normalized;

            // Orientar al personaje hacia la portería antes de golpear
            transform.rotation = Quaternion.LookRotation(goalDirection);

            // Golpear la pelota en la dirección de la portería
            other.GetComponent<Rigidbody>().velocity = goalDirection * FORCE;
        }
    }
}
