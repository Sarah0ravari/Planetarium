using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Body : MonoBehaviour {
    public float Mass = 1;
    public Vector3 Velocity;
    public bool EnabledOrbitVisual;
    private const float G = 6.673e-11F;   // gravitational constant
    private Vector3 force;

    public void UpdateVelocity(float dt) {
        Velocity += (dt * force / Mass) * 1e9F;
    }
    public void UpdateVelocityX(float newx) {
        Velocity.z = newx;
    }
    public void UpdateVelocityY(float newy) {
        Velocity.z = newy;
    }
    public void UpdateVelocityZ(float newz) {
        Velocity.z = newz;
    }
    public float getXVelocity(){
        return Velocity.x;
    }
    public float getYVelocity(){
        return Velocity.y;
    }
    public float getZVelocity(){
        return Velocity.z;
    }

    public void UpdatePosition(float dt) {
        transform.position += dt * (Velocity * 1e-9F);
    }

    public float DistanceTo(Body b) {
        return Vector3.Distance(transform.position, b.transform.position);
    }

    public void ResetForce() {
        force = Vector3.zero;
    }
    //added for slider
    public void AdjustMass(float newMass){
        Mass = newMass;
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
