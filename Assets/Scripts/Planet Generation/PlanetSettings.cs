using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlanetSettings
{
    //Shape Settings
    [Range(1f, 50f)]
    public float planetRadius = 1;

    //Color Settings
    public Color planetColor = Color.white;

    public NoiseSettings[] noiseSettings;

    public PlanetSettings()
    {
        this.noiseSettings = new NoiseSettings[3];
    }

    [System.Serializable]
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
