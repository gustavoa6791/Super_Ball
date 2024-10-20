using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_center : MonoBehaviour
{
    public GameObject ball; // Referencia al objeto Ball

    // Start is called before the first frame update
    void Start()
    {
        // Obtener los colliders del muro y la bola
        Collider wallCollider = GetComponent<Collider>();
        Collider ballCollider = ball.GetComponent<Collider>();

        // Ignorar colisiones entre el muro y la bola
        Physics.IgnoreCollision(wallCollider, ballCollider);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
