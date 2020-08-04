using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class Player_Agent : Agent
{
    private Rigidbody rBody;
    public float playerSpeed = 2f;
    public float jumpSpeed = 0.5f;
    public Transform Target;
    public Transform Obstacle1;
    public Transform Obstacle2;
    public Transform Obstacle3;
    Vector3 startPosition;
    Vector3 position;

    void Start()
    {
        startPosition = transform.position;
        rBody = GetComponent<Rigidbody>();
    }

    public override void OnEpisodeBegin()
    {
        if (transform.position.y < -1.5)
        {
            transform.position = startPosition;
            rBody.velocity = Vector3.zero;
        }
    }

    public override void CollectObservations(VectorSensor sensor)
    {

        sensor.AddObservation(Target.localPosition);
        sensor.AddObservation(this.transform.localPosition);


        sensor.AddObservation(rBody.velocity.x);
        sensor.AddObservation(rBody.velocity.y);
        sensor.AddObservation(rBody.velocity.z);
    }

    public override void OnActionReceived(float[] vectorAction)
    {

        Vector3 controlSignal = Vector3.zero;
        controlSignal.x = vectorAction[0];
        controlSignal.y = vectorAction[1];
        controlSignal.z = vectorAction[2];
        rBody.AddForce(controlSignal * playerSpeed);
        rBody.AddForce(controlSignal * jumpSpeed, ForceMode.Impulse);

        
        float distanceToTarget = Vector3.Distance(this.transform.localPosition, Target.localPosition);


        // Existencial Reward
        SetReward(1.0f);

        // Target
        if (distanceToTarget < 0.1f)
        {
            SetReward(1.0f);
            EndEpisode();
        }


        // Platform
        else if(this.transform.localPosition.y < -1.5f || this.transform.localPosition.y > 3f)
        {
            EndEpisode();
        }
    }

}