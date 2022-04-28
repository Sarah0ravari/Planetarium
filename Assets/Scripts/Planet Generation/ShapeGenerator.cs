using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator
{
    PlanetSettings settings;
    NoiseFilter noiseFilter;

    public ShapeGenerator(PlanetSettings settings)
    {
        this.settings = settings;
        noiseFilter = new NoiseFilter(this.settings);
    }

    public Vector3 CalculatePointOnPlanet(Vector3 pointOnUnitSphere)
    {
        float elevation = noiseFilter.Evaluate(pointOnUnitSphere);
        return pointOnUnitSphere * settings.planetRadius * (1 + elevation);
    }
}
