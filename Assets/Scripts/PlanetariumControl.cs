using SaveIsEasy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetariumControl : MonoBehaviour
{
    public static PlanetariumControl Instance { get; private set; }
    public PhysicsSimulation simulation;
    public OrbitVisualizer orbitVisualizer;

    public Material planetMaterial;
    public Material atmosphereMaterial;

    public ArrayList planetSettings;
    private ArrayList planets;
    public string newPlanetSettings;

    public Vector3 cameraPosition;
    public Quaternion cameraRotation;

    public VelocityMassChanger velocityMassChanger;
    public Planet selectedPlanet;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); 
        if (Instance is null)
        {
            Instance = this;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public PlanetariumControl()
    {
        planetSettings = new ArrayList();
        planets = new ArrayList();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Main")
        {
            Physics.queriesHitTriggers = true;

            GameObject go = GameObject.Find("PhysicsSimulation"); 
            if (go is not null)
            {
                simulation = go.GetComponent<PhysicsSimulation>();
                orbitVisualizer = go.GetComponent<OrbitVisualizer>();
            }

            if (newPlanetSettings is not null)
            {
                planetSettings.Add(newPlanetSettings);
                newPlanetSettings = null;
            }

            Camera.main.transform.position = cameraPosition;
            Camera.main.transform.rotation = cameraRotation;

            CreatePlanets();
        }
    }

    void CreatePlanets()
    {
        foreach(string planetJSON in planetSettings)
        {
            PlanetSettings planetSettings = JsonUtility.FromJson<PlanetSettings>(planetJSON);

            GameObject obj = new GameObject();
            obj.name = "Planet";
            Planet planet = obj.AddComponent<Planet>();
            planet.settings = planetSettings;
            planet.material = this.planetMaterial;
            planet.atmosphereMaterial = this.atmosphereMaterial;
            planets.Add(planet);

            Body body = obj.AddComponent<Body>();
            body.Mass = Random.Range(1, 100);
            body.Velocity = new Vector3(0, 0, 0);
            simulation.bodies.Add(body);
            orbitVisualizer.addBody(body);


            Rigidbody rb = obj.AddComponent<Rigidbody>();
            rb.isKinematic = true;
            SphereCollider sphereCollider = obj.AddComponent<SphereCollider>();
            sphereCollider.isTrigger = true;
            sphereCollider.radius = planet.settings.planetRadius;

            if (planetSettings.mainScenePosition == Vector3.zero)
            {
                obj.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 10;
            }
            else
            {
                obj.transform.position = planetSettings.mainScenePosition;
            }
        }
    }

    public void SavePlanetPositions()
    {
        cameraPosition = Camera.main.transform.position;
        cameraRotation = Camera.main.transform.rotation;

        int index = 0;
        foreach (Planet planet in planets)
        {
            planet.settings.mainScenePosition = planet.transform.position;
            string planetJSON = JsonUtility.ToJson(planet.settings);
            planetSettings[index] = planetJSON;
            index++;
        }
        planets.Clear();
    }

    public void SetSelectedPlanet(Planet planet)
    {
        if (planet is not null)
        {
            selectedPlanet = planet;
            if (velocityMassChanger != null)
            {
                velocityMassChanger.updateDisplayedValues();
            }
        }
    }
}
