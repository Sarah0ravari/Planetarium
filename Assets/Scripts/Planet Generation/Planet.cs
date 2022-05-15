/*
 * Based in part on Sebastian Lague's Procedural Planets video series
 * https://youtu.be/QN39W020LqU
 * Licensed under the MIT license
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [Range(2, 256)]
    public int resolution = 128;
    public Material material;

    [SerializeField, HideInInspector]
    MeshFilter[] meshFilters;
    TerrainFace[] terrainFaces;

    public PlanetSettings settings = new PlanetSettings();
    ShapeGenerator shapeGenerator;
    ColorGenerator colorGenerator;

    bool generationEnabled = true;

    public void Start()
    {
        settings.material = material;
        shapeGenerator = new ShapeGenerator(settings);
        colorGenerator = new ColorGenerator(settings);
        meshFilters = new MeshFilter[6];
        terrainFaces = new TerrainFace[6];

        Vector3[] directions = { Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };

        for (int i = 0; i < 6; i++)
        {
            if (meshFilters[i] == null)
            {
                GameObject meshObj = new GameObject("mesh");
                meshObj.transform.parent = transform;

                meshObj.AddComponent<MeshRenderer>().sharedMaterial = material;
                meshFilters[i] = meshObj.AddComponent<MeshFilter>();
                meshFilters[i].sharedMesh = new Mesh();
            }

            terrainFaces[i] = new TerrainFace(shapeGenerator, meshFilters[i].sharedMesh, resolution, directions[i]);
        }

        GeneratePlanet();
    }

    void GeneratePlanet()
    {
        GenerateMesh();
        GenerateColors();
    }

    public void GenerateMesh()
    {
        if (!generationEnabled) return;

        shapeGenerator.elevationMinMax.Reset();

        foreach (TerrainFace face in terrainFaces)
        {
            face.ConstructMesh();
        }

        colorGenerator.UpdateElevation(shapeGenerator.elevationMinMax);
    }

    public void GenerateColors()
    {
        if (!generationEnabled) return;

        if (colorGenerator != null)
        {
            colorGenerator.UpdateColors();
        }
    }

    public void Randomize(PlanetGenerationUI ui)
    {
        generationEnabled = false;

        settings.noiseSettings[0].strength = Random.Range(0.1f, 0.6f);
        ui.baseStrengthLabel.text = settings.noiseSettings[0].strength.ToString("0.0");
        ui.baseStrengthSlider.value = settings.noiseSettings[0].strength;
        settings.noiseSettings[0].baseRoughness = Random.Range(0.0f, 1.0f);
        ui.baseFrequencyLabel.text = settings.noiseSettings[0].roughness.ToString("0.0");
        ui.baseFrequencySlider.value = settings.noiseSettings[0].roughness;
        settings.noiseSettings[0].numLayers = Random.Range(2, 7);
        ui.baseDetailLabel.text = settings.noiseSettings[0].numLayers.ToString("0.0");
        ui.baseDetailSlider.value = settings.noiseSettings[0].numLayers;
        settings.noiseSettings[0].roughness = Random.Range(0.5f, 3.0f);
        ui.baseDetailFrequencyLabel.text = settings.noiseSettings[0].roughness.ToString("0.0");
        ui.baseDetailFrequencySlider.value = settings.noiseSettings[0].roughness;
        settings.noiseSettings[0].persistance = Random.Range(0.3f, 0.7f);
        ui.baseAmplitudeLabel.text = settings.noiseSettings[0].persistance.ToString("0.0");
        ui.baseAmplitudeSlider.value = settings.noiseSettings[0].persistance;
        settings.noiseSettings[0].center = new Vector3(Random.Range(0.0f, 10.0f), Random.Range(0.0f, 10.0f), Random.Range(0.0f, 10.0f));

        settings.noiseSettings[1].strength = Random.Range(0.0f, 0.6f);
        ui.midStrengthLabel.text = settings.noiseSettings[1].strength.ToString("0.0");
        ui.midStrengthSlider.value = settings.noiseSettings[1].strength;
        settings.noiseSettings[1].baseRoughness = Random.Range(0.0f, 1.0f);
        ui.midFrequencyLabel.text = settings.noiseSettings[1].roughness.ToString("0.0");
        ui.midFrequencySlider.value = settings.noiseSettings[1].roughness;
        settings.noiseSettings[1].numLayers = Random.Range(2, 7);
        ui.midDetailLabel.text = settings.noiseSettings[1].numLayers.ToString("0.0");
        ui.midDetailSlider.value = settings.noiseSettings[1].numLayers;
        settings.noiseSettings[1].roughness = Random.Range(0.0f, 2.0f);
        ui.midDetailFrequencyLabel.text = settings.noiseSettings[1].roughness.ToString("0.0");
        ui.midDetailFrequencySlider.value = settings.noiseSettings[1].roughness;
        settings.noiseSettings[1].persistance = Random.Range(0.0f, 0.8f);
        ui.midAmplitudeLabel.text = settings.noiseSettings[1].persistance.ToString("0.0");
        ui.midAmplitudeSlider.value = settings.noiseSettings[1].persistance;
        settings.noiseSettings[1].center = new Vector3(Random.Range(0.0f, 10.0f), Random.Range(0.0f, 10.0f), Random.Range(0.0f, 10.0f));

        settings.noiseSettings[2].strength = Random.Range(0.0f, 0.5f);
        ui.topStrengthLabel.text = settings.noiseSettings[2].strength.ToString("0.0");
        ui.topStrengthSlider.value = settings.noiseSettings[2].strength;
        settings.noiseSettings[2].baseRoughness = Random.Range(0.0f, 1.0f);
        ui.topFrequencyLabel.text = settings.noiseSettings[2].roughness.ToString("0.0");
        ui.topFrequencySlider.value = settings.noiseSettings[2].roughness;
        settings.noiseSettings[2].numLayers = Random.Range(2, 7);
        ui.topDetailLabel.text = settings.noiseSettings[2].numLayers.ToString("0.0");
        ui.topDetailSlider.value = settings.noiseSettings[2].numLayers;
        settings.noiseSettings[2].roughness = Random.Range(0.0f, 2.0f);
        ui.topDetailFrequencyLabel.text = settings.noiseSettings[2].roughness.ToString("0.0");
        ui.topDetailFrequencySlider.value = settings.noiseSettings[2].roughness;
        settings.noiseSettings[2].persistance = Random.Range(0.0f, 0.8f);
        ui.topAmplitudeLabel.text = settings.noiseSettings[2].persistance.ToString("0.0");
        ui.topAmplitudeSlider.value = settings.noiseSettings[2].persistance;
        settings.noiseSettings[2].center = new Vector3(Random.Range(0.0f, 10.0f), Random.Range(0.0f, 10.0f), Random.Range(0.0f, 10.0f));
        settings.noiseSettings[2].weightMultiplier = Random.Range(0.1f, 1.0f);

        this.settings.colorKeys[0].color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        ui.baseColor.color = this.settings.colorKeys[0].color;
        this.settings.colorKeys[1].color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        ui.midColor.color = this.settings.colorKeys[1].color;
        this.settings.colorKeys[2].color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        ui.topColor.color = this.settings.colorKeys[2].color;
        this.settings.gradient.SetKeys(this.settings.colorKeys, this.settings.alphaKeys);

        generationEnabled = true;
        GeneratePlanet();
    }

}
