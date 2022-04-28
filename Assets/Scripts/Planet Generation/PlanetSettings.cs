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

    //Noise Settings
    public float noiseStrength = 1;
    [Range(1,8)]
    public int noiseNumLayers = 1;
    public float noiseBaseRoughness = 1;
    public float noiseRoughness = 2;
    public float noisePersistance = 0.5f;
    public Vector3 noiseCenter;
    public float noiseMinValue = 1;
}
