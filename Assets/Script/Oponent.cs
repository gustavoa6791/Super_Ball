using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oponent : MonoBehaviour
{
    public float SPEED = 1.5f;
    public float FORCE = 10f;
    public float ROTATION = 1f;
    public Transform ball;
    Vector3 targetPosistion;
    Vector3 prevPosition;
    Vector3 centerPosition = new Vector3(0, 0, 10);

    private Vector3 movementDirection;

    public Animator animator;



    // Start is called before the first frame update
    void Start() {
        targetPosistion = transform.position;
        prevPosition = transform.position; 
    }

    // Update is called once per frame
    void Update() {     
    }

    private void FixedUpdate()
    {

        

        targetPosistion.x = ball.position.x;

        if (ball.position.z <= 0){
            transform.position = Vector3.MoveTowards(transform.position, centerPosition, SPEED-0.12f);
        }
        else{
            transform.position = Vector3.MoveTowards(transform.position,targetPosistion,SPEED);
        }

        Vector3 movementXZ = new Vector3(transform.position.x - prevPosition.x, 0, transform.position.z - prevPosition.z);
        movementDirection = movementXZ.normalized;

        Debug.Log(movementXZ.magnitude);
        if (movementXZ.magnitude > 0.02f   )
        {

            animator.SetFloat("MOVE", 1f, 0.1f, Time.deltaTime);
            
                transform.rotation = Quaternion.LookRotation(movementDirection);
            
           


        } else {
            animator.SetFloat("MOVE", 0, 0.1f, Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(new Vector3(0,0,-1));
        }

        prevPosition = transform.position;

    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 target = new Vector3(0, 0, 10);

        if (other.CompareTag("BALL")) {
            Vector3 direction = target - transform.position;
            other.GetComponent<Rigidbody>().velocity = direction.normalized * FORCE;
        };
    }
}
