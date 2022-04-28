using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseFilter
{
    PlanetSettings settings;
    Noise noise = new Noise();

    public NoiseFilter(PlanetSettings settings)
    {
        this.settings = settings;
    }

    public float Evaluate(Vector3 point)
    {
        float noiseValue = 0;
        float frequency = settings.noiseBaseRoughness;
        float amplitude = 1;

        for (int i = 0;i < settings.noiseNumLayers;i++)
        {
            float v = noise.Evaluate(point * frequency + settings.noiseCenter);
            noiseValue += (v + 1) * 0.5f * amplitude;
            frequency *= settings.noiseRoughness;
            amplitude *= settings.noisePersistance;
        }

        noiseValue = Mathf.Max(0, noiseValue - settings.noiseMinValue);
        return noiseValue * settings.noiseStrength;
    }
}
