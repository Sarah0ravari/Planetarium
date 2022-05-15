using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitVisualizer : MonoBehaviour {
    public bool Enabled = false;
    public float Dt = 100000000;
    public int NumSteps = 0;
    private List<Body> bodies;
    private List<Body> bodyCopies;
    private Vector3[][] positionsByStep;

    void FixedUpdate() {
        if (!Enabled) return;
        positionsByStep = new Vector3[bodyCopies.Count][];
        for (int i = 0; i < positionsByStep.Length; i++) {
            positionsByStep[i] = new Vector3[NumSteps];
        }
        for (int step = 0; step < NumSteps; step++) {
            PhysicsSimulation.AddForces(bodyCopies);
            PhysicsSimulation.UpdateVelocities(bodyCopies, Dt);
            PhysicsSimulation.UpdatePositions(bodyCopies, Dt);
            for (int body = 0; body < bodyCopies.Count; body++) {
                positionsByStep[body][step] = bodyCopies[body].transform.position;
            }
        }
        for (int body = 0; body < bodyCopies.Count; body++) {
            LineRenderer line = bodyCopies[body].GetComponent<LineRenderer>();
            if (bodies[body].EnabledOrbitVisual) {
                line.positionCount = NumSteps;
                line.SetPositions(positionsByStep[body]);
            } else {
                line.positionCount = 0;
            }
        }
        for (int body = 0; body < bodyCopies.Count; body++) {
            bodyCopies[body].transform.position = bodies[body].transform.position;
            bodyCopies[body].Velocity = bodies[body].Velocity;
        }
    }

    void Start() {
        bodies = new List<Body>(gameObject.GetComponentsInChildren<Body>());
        bodyCopies = new List<Body>();
        for (int i = 0; i < bodies.Count; i++) {
            bodyCopies.Add(Object.Instantiate(bodies[i].gameObject).GetComponent<Body>());
            LineRenderer line = bodyCopies[i].gameObject.AddComponent<LineRenderer>();
            line.startWidth = 0.1f;
            line.endWidth = 0.1f;
            line.startColor = Color.white;
            line.endColor = Color.white;
            Material whiteDiffuseMat = new Material(Shader.Find("Unlit/Texture"));
            line.material = whiteDiffuseMat;
        }
    }
}
