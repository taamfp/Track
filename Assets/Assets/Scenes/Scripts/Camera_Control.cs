using UnityEngine;

public class Camera_Control : MonoBehaviour
{

    //Same as player speed
    public float cameraSpeed = 10.0f;


    void Update()
    {
        Vector3 local = transform.position;

        if (Input.GetKey("w"))
        {
            local.z += -cameraSpeed * Time.deltaTime;
        }

        else if (Input.GetKey("a"))
        {
            local.z += cameraSpeed * Time.deltaTime;
        }

        else if (Input.GetKey("s"))
        {
            local.x += -cameraSpeed * Time.deltaTime;
        }

        else if (Input.GetKey("t"))
        {
            local.x += cameraSpeed * Time.deltaTime;
        }

        transform.position = local;
    }
}
