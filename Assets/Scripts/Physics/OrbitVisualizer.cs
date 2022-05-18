using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitVisualizer : MonoBehaviour {
    public bool Enabled = false;
    public int NumSteps = 500;
    private List<Body> bodies = new List<Body>();
    private List<Body> bodyCopies = new List<Body>();
    private Vector3[][] positionsByStep;
    private PhysicsSimulation physicsInstance;

    public void addBody(Body body) {
        bodies.Add(body);
        Body bodyCopy = Object.Instantiate(body.gameObject).GetComponent<Body>();
        bodyCopies.Add(bodyCopy);
        LineRenderer line = bodyCopy.gameObject.AddComponent<LineRenderer>();
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        line.startColor = Color.white;
        line.endColor = Color.white;
        Material whiteDiffuseMat = new Material(Shader.Find("Unlit/Texture"));
        line.material = whiteDiffuseMat;
    }

    void FixedUpdate() {
        if (!Enabled) return;
        positionsByStep = new Vector3[bodyCopies.Count][];
        for (int i = 0; i < positionsByStep.Length; i++) {
            positionsByStep[i] = new Vector3[NumSteps];
        }
        for (int step = 0; step < NumSteps; step++) {
            for (int i = 0; i < physicsInstance.StepsPerUpdate; i++) {
                PhysicsSimulation.AddForces(bodyCopies);
                PhysicsSimulation.UpdateVelocities(bodyCopies, physicsInstance.Dt);
                PhysicsSimulation.UpdatePositions(bodyCopies, physicsInstance.Dt);
            }
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
        physicsInstance = gameObject.GetComponent<PhysicsSimulation>();
    }
}
