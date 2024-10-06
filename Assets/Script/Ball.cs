using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float[] initial = { -5f, 5f };
        int Xramdon = (int)Random.Range(0, 1.9f);
        int Yramdon = (int)Random.Range(0, 1.9f);
        GetComponent<Rigidbody>().velocity = new Vector3(initial[Xramdon], 0, initial[Yramdon]);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
