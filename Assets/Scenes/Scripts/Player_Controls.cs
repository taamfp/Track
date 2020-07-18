using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controls : MonoBehaviour
{
    private Rigidbody rBody;
    public float playerSpeed = 0.5f;
    Vector3 startposition;
    Vector3 position;


    void Start()
    {
        startposition = transform.position;
        rBody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        position = new Vector3(moveH, 0, moveV);
        rBody.AddForce(position * playerSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cube")
        {
            position = startposition;
        }
    }
}