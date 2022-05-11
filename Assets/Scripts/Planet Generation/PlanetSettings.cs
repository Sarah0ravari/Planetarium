using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSettings
{
    //Shape Settings
    [Range(1f, 5f)]
    public float planetRadius = 2.5f;

    //Color Settings
    public Gradient gradient;
    public Material material;

    public NoiseSettings[] noiseSettings;

    public PlanetSettings()
    {
        this.noiseSettings = new NoiseSettings[]
        {
            new NoiseSettings(),
            new NoiseSettings(),
            new NoiseSettings(),
        };
        this.gradient = new Gradient();
    }

    public class NoiseSettings
    {
        public bool enabled = true;
        public bool useFirstLayerAsMask;
        public float strength = 1;
        [Range(1, 8)]
        public int numLayers = 1;
        public float baseRoughness = 1;
        public float roughness = 2;
        public float persistance = 0.5f;
        public Vector3 center;
        public float minValue = 1;
        public float weightMultiplier = 0.8f;
    }
}
