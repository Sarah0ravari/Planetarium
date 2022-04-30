using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator
{
    PlanetSettings settings;
    INoiseFilter[] noiseFilters;

    public ShapeGenerator(PlanetSettings settings)
    {
        this.settings = settings;
        noiseFilters = new INoiseFilter[settings.noiseSettings.Length];
        //Two Simple Noise Filters and a Ridge Filter
        noiseFilters[0] = new SimpleNoiseFilter(settings.noiseSettings[0]);
        noiseFilters[1] = new SimpleNoiseFilter(settings.noiseSettings[1]);
        noiseFilters[2] = new RidgeNoiseFilter(settings.noiseSettings[2]);
    }

    public Vector3 CalculatePointOnPlanet(Vector3 pointOnUnitSphere)
    {
        float firstLayerValue = 0;
        float elevation = 0;

        if (noiseFilters.Length > 0)
        {
            firstLayerValue = noiseFilters[0].Evaluate(pointOnUnitSphere);
            if (settings.noiseSettings[0].enabled)
            {
                elevation = firstLayerValue;
            }
        }

        for (int i = 1; i < noiseFilters.Length; i++)
        {
            if (settings.noiseSettings[i].enabled)
            {
                float mask = (settings.noiseSettings[i].useFirstLayerAsMask) ? firstLayerValue : 1;
                elevation += noiseFilters[i].Evaluate(pointOnUnitSphere) * mask;
            }
        }
        return pointOnUnitSphere * settings.planetRadius * (1 + elevation);
    }
}
