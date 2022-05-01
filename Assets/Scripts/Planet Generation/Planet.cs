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
        shapeGenerator.elevationMinMax.Reset();

        foreach (TerrainFace face in terrainFaces)
        {
            face.ConstructMesh();
        }

        colorGenerator.UpdateElevation(shapeGenerator.elevationMinMax);
    }

    public void GenerateColors()
    {
        colorGenerator.UpdateColors();
    }

}
