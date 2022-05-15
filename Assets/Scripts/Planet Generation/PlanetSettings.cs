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
    public GradientColorKey[] colorKeys;
    public GradientAlphaKey[] alphaKeys;
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

        this.noiseSettings[1].useFirstLayerAsMask = true;
        this.noiseSettings[2].useFirstLayerAsMask= true;

        this.gradient = new Gradient();
        this.colorKeys = new GradientColorKey[3];
        this.colorKeys[0].color = Color.white;
        this.colorKeys[0].time = 0.0f;
        this.colorKeys[1].color = Color.gray;
        this.colorKeys[1].time = 0.5f;
        this.colorKeys[2].color = Color.black;
        this.colorKeys[2].time = 1.0f;

        this.alphaKeys = new GradientAlphaKey[2];
        this.alphaKeys[0].alpha = 1.0f;
        this.alphaKeys[0].time = 0.0f;
        this.alphaKeys[1].alpha = 1.0f;
        this.alphaKeys[1].time = 1.0f;

        this.gradient.SetKeys(this.colorKeys, this.alphaKeys);
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
