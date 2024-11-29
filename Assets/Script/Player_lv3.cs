using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_lv3 : MonoBehaviour
{

    public float SPEED = 0.2f;
    public float ROTATION = 1f;
    public float FORCE = 10f;
    private float X, Y;
    private bool ATTACK;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        X = Input.GetAxis("Horizontal");
        Y = Input.GetAxis("Vertical");

        ATTACK = Input.GetKeyDown(KeyCode.Space);


        if (ATTACK)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(0, 0, 0)), ROTATION);
            animator.SetTrigger("ATTACK");
        }

    }

    private void FixedUpdate()
    {


        if ((X != 0 || Y != 0) && !ATTACK)
        {

            Vector3 direction = new Vector3(X, 0, Y);

            transform.position = transform.position + direction * SPEED;

            if (Y >= 0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), ROTATION);
            }
            animator.SetFloat("MOVE", 1f, 0.1f, Time.deltaTime);
        }
        else
        {
            animator.SetFloat("MOVE", 0, 0.1f, Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(0, 0, 0)), ROTATION);

        }
    }

    // custom sebas
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BALL"))
        {
            // Genera una dirección aleatoria hacia adelante
            Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(0f, 1f)).normalized;

            // Aplica la dirección aleatoria multiplicada por la fuerza
            other.GetComponent<Rigidbody>().velocity = randomDirection * FORCE;
        }
    }

}
