using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsSimulation : MonoBehaviour {
    public bool Paused = true;
    public float Dt = 100000000;
    public List<Body> bodies;

    public static void AddForces(List<Body> bodies) {
        for (int i = 0; i < bodies.Count; i++) {
            bodies[i].ResetForce();
            for (int j = 0; j < bodies.Count; j++) {
                if (i != j) bodies[i].AddForce(bodies[j]);
            }
        }
    }

    public static void UpdateVelocities(List<Body> bodies, float dt) {
        for (int i = 0; i < bodies.Count; i++) {
            bodies[i].UpdateVelocity(dt);
        }
    }

    public static void UpdatePositions(List<Body> bodies, float dt) {
        for (int i = 0; i < bodies.Count; i++) {
            bodies[i].UpdatePosition(dt);
        }
    }

    void Start() {
        bodies = new List<Body>(gameObject.GetComponentsInChildren<Body>());
    }

    void FixedUpdate() {
        if (Paused) return; 
        AddForces(bodies);
        UpdateVelocities(bodies, Dt);
        UpdatePositions(bodies, Dt);
    }
}
