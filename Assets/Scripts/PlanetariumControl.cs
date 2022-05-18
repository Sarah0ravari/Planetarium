using SaveIsEasy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetariumControl : MonoBehaviour
{
    public static PlanetariumControl Instance { get; private set; }
    public PhysicsSimulation simulation;

    public Material planetMaterial;
    public Material atmosphereMaterial;

    public ArrayList planetSettings;
    public string newPlanetSettings;

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
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Main")
        {
            GameObject go = GameObject.Find("PhysicsSimulation"); 
            if (go is not null)
            {
                simulation = go.GetComponent<PhysicsSimulation>();
            }

            if (newPlanetSettings is not null)
            {
                planetSettings.Add(newPlanetSettings);
                newPlanetSettings = null;
            }

            CreatePlanets();
        }
    }

    void CreatePlanets()
    {
        foreach(string planetJSON in planetSettings)
        {
            PlanetSettings planetSettings = JsonUtility.FromJson<PlanetSettings>(planetJSON);

            GameObject obj = new GameObject();
            Planet planet = obj.AddComponent<Planet>();
            planet.settings = planetSettings;
            planet.material = this.planetMaterial;
            planet.atmosphereMaterial = this.atmosphereMaterial;

            Body body = obj.AddComponent<Body>();
            body.Mass = Random.Range(1, 100);
            body.Velocity = new Vector3(0.0000001f, 0, 0);

            obj.gameObject.AddComponent<SaveIsEasyComponent>();
            obj.gameObject.AddComponent<ChangeLookAtTarget>();
            obj.gameObject.AddComponent<RotateAround>();
            obj.gameObject.AddComponent<PlanetGUI>();

            obj.transform.parent = simulation.transform;
            obj.transform.position = new Vector3(Random.Range(0, 400), 0, 0);
            simulation.bodies.Add(body);

            planet.GenerateColors();

            //Old View Scripts, disable when LookAt script works
            var viewControls = Camera.main.GetComponent<GlobeViewControls>();
            viewControls.globe = obj.transform;
        }
    }
}
