using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float SPEED = 0.2f;
    public float ROTATION = 1f;
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

        ATTACK = Input.GetKeyUp(KeyCode.Space);

        Debug.Log(ATTACK);
        if (ATTACK)
        {
            animator.SetTrigger("ATTACK");
        }

    }
    
    private void FixedUpdate() {
       

        if ( (X != 0 || Y != 0) && !ATTACK ){

            Vector3 direction = new Vector3(X, 0, Y); 

            transform.position = transform.position + direction * SPEED;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), ROTATION);

            animator.SetFloat("MOVE", 1f, 0.1f, Time.deltaTime);
        }else{
            animator.SetFloat("MOVE", 0, 0.1f, Time.deltaTime);
        }

        


       
    }
}
