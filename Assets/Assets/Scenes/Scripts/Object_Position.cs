using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{

    private Rigidbody rBodyCube;
    Vector3 startPositionCube;


    void Start()
    {
        startPositionCube = transform.position;
        rBodyCube = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (transform.position.y < -1.5)
        {
            transform.position = startPositionCube;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            transform.position = startPositionCube;
        }
    }

}