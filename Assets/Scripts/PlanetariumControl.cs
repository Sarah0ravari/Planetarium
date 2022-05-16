using SaveIsEasy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetariumControl : MonoBehaviour
{
    public static PlanetariumControl Instance { get; private set; }
    public PhysicsSimulation simulation;

    public Planet newPlanet;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); 
        if (Instance is null)
        {
            Instance = this;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject go = GameObject.Find("PhysicsSimulation"); 
        if (go is not null)
        {
            simulation = go.GetComponent<PhysicsSimulation>();
        }

        if (newPlanet is not null)
        {
            AddNewPlanet();
        }
    }

    void AddNewPlanet()
    {
        Debug.Log("Adding new planet");

        Body body = newPlanet.gameObject.AddComponent<Body>();
        newPlanet.gameObject.AddComponent<SaveIsEasyComponent>();
        newPlanet.gameObject.AddComponent<ChangeLookAtTarget>();

        newPlanet.transform.parent = simulation.transform;
        simulation.bodies.Add(body);

        //Old View Scripts, disable when LookAt script works
        var viewControls = Camera.main.GetComponent<GlobeViewControls>();
        viewControls.globe = newPlanet.transform;

        newPlanet = null;
    }
}
