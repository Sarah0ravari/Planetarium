using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour {
    public float Mass = 1;
    public Vector3 Velocity;
    private const float G = 6.673e-11F;   // gravitational constant
    private Vector3 force;

    public void UpdateVelocity(float dt) {
        Velocity += dt * force / Mass;
    }

    public void UpdatePosition(float dt) {
        transform.position += dt * Velocity;
    }

    public float DistanceTo(Body b) {
        return Vector3.Distance(transform.position, b.transform.position);
    }

    public void ResetForce() {
        force = Vector3.zero;
    }

    // compute the net force acting between the body a and b, and
    // add to the net force acting on a
    public void AddForce(Body b) {
        float EPS = 3E4F;      // softening parameter (just to avoid infinities)
        Vector3 diff = b.transform.position - transform.position;
        float dist = DistanceTo(b);
        float F = (G * Mass * b.Mass) / (dist*dist + EPS*EPS);
        force += F * diff / dist;
    }
}
