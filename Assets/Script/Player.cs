using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float SPEED = 0.2f;
    public float ROTATION = 1f;
    public float FORCE = 10f;
    private float X, Y;
    private bool ATTACK;
    public Animator animator ;


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
    
    private void FixedUpdate() {
       

        if ( (X != 0 || Y != 0) && !ATTACK ){

            Vector3 direction = new Vector3(X, 0, Y); 

            transform.position = transform.position + direction * SPEED;

            if (Y >= 0) {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), ROTATION);
            }
            animator.SetFloat("MOVE", 1f, 0.1f, Time.deltaTime);
        }else{
            animator.SetFloat("MOVE", 0, 0.1f, Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(0,0,0)), ROTATION);

        }
    }

    // custom gustavo 

    private void OnTriggerEnter(Collider other)
    {
        Vector3 target = new Vector3(0, 0, 10);

        if (other.CompareTag("BALL"))
        {
            Vector3 direction = target - transform.position;
            other.GetComponent<Rigidbody>().velocity = direction.normalized * FORCE;
        };
    }

}
