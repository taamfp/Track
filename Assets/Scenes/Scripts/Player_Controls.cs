using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controls : MonoBehaviour
{
    private Rigidbody rBody;
    public float playerSpeed = 0.5f;
    public float jumpSpeed = 0.5f;
    Vector3 startPosition;
    Vector3 position;
    Quaternion startRotation;
    Quaternion rotation;


    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
        rBody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");


        position = new Vector3(moveH, 0.0f, moveV);
        rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, 0);
        rBody.AddForce (position * playerSpeed);

        if (transform.position.y < -1.5)
        {
            transform.position = startPosition;
            transform.rotation = startRotation;
            rBody.velocity = Vector3.zero;
        }

        if (Input.GetKeyDown("space"))
        {
            rBody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cube")
        {
            transform.position = startPosition;
            transform.rotation = startRotation;
            rBody.velocity = Vector3.zero;
        }
    }
}