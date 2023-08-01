using System.Collections.Generic;
using UnityEngine;

public class WeightScale : MonoBehaviour
{
    public float forceToMass;
    public float combinedForce;
    public float calculatedMass;
    public int registeredRigidbodies;

    readonly Dictionary<Rigidbody, float> impulsePerRigidBody = new();

    float currentDeltaTime;
    float lastDeltaTime;

    private void Awake()
    {
        forceToMass = 1f / Physics.gravity.magnitude;
    }

    public void UpdateWeight()
    {
        registeredRigidbodies = impulsePerRigidBody.Count;
        combinedForce = 0;

        foreach (var force in impulsePerRigidBody.Values)
        {
            combinedForce += force;
        }

        calculatedMass = combinedForce * forceToMass;
    }

    private void FixedUpdate()
    {
        lastDeltaTime = currentDeltaTime;
        currentDeltaTime = Time.deltaTime;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.rigidbody != null)
        {
            if (impulsePerRigidBody.ContainsKey(collision.rigidbody))
                impulsePerRigidBody[collision.rigidbody] = collision.impulse.y / lastDeltaTime;
            else
                impulsePerRigidBody.Add(collision.rigidbody, collision.impulse.y / lastDeltaTime);

            UpdateWeight();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.rigidbody != null)
        {
            impulsePerRigidBody.Remove(collision.rigidbody);
            UpdateWeight();
        }
    }
}
