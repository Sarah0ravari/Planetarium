using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitVisualizer : MonoBehaviour {
    public bool Enabled = false;
    public float Dt = 100000000;
    public int NumSteps = 0;
    private List<Body> bodies;
    private List<Body> bodyCopies;

    void OnUpdate() {
        if (!Enabled) return;
        bodyCopies = new List<Body>();
        foreach (Body body in bodies) {
            bodyCopies.Add(Object.Instantiate(body.gameObject).AddComponent<LineRenderer>().GetComponent<Body>());
        }
        Vector3[][] positionsByStep = new Vector3[bodyCopies.Count][];
        for (int i = 0; i < positionsByStep.Length; i++) {
            positionsByStep[i] = new Vector3[NumSteps];
        }
        for (int i = 0; i < NumSteps; i++) {
            PhysicsSimulation.AddForces(bodyCopies);
            PhysicsSimulation.UpdateVelocities(bodyCopies, Dt);
            PhysicsSimulation.UpdatePositions(bodyCopies, Dt);
            for (int j = 0; j < bodyCopies.Count; j++) {
                positionsByStep[j][i] = bodyCopies[j].transform.position;
            }
        }
        for (int i = 0; i < bodyCopies.Count; i++) {
            bodyCopies[i].GetComponent<LineRenderer>().SetPositions(positionsByStep[i]);
        }
        foreach (Body body in bodyCopies) {
            Object.Destroy(body);
        }
    }

    void Start() {
        bodies = new List<Body>(gameObject.GetComponentsInChildren<Body>());
    }
}
