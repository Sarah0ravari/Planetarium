using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGenerationUI : MonoBehaviour
{
    public Planet planet;
    public Material material;
    public TMPro.TextMeshProUGUI scaleText;
    public TMPro.TextMeshProUGUI radiusText;

    public TMPro.TextMeshProUGUI baseStrengthLabel;
    public TMPro.TextMeshProUGUI baseFrequencyLabel;
    public TMPro.TextMeshProUGUI baseDetailLabel;
    public TMPro.TextMeshProUGUI baseDetailFrequencyLabel;
    public TMPro.TextMeshProUGUI baseAmplitudeLabel;

    enum NoiseType
    {
        Perlin,
        Simplex
    }
    NoiseType currentNoiseType = NoiseType.Perlin;

    Simplex.Noise simplexNoise = new Simplex.Noise();

    private MeshRenderer meshRenderer;

    private Texture2D texture;

    int texWidth = 512, texHeight = 512;
    // Start is called before the first frame update
    void Start()
    {
        texture = new Texture2D(texWidth, texHeight, TextureFormat.ARGB32, false);
        regenerateTexture();
    }

    void regenerateTexture()
    {
        for (int i = 0; i < texHeight; i++)
        {
            for (int j = 0; j < texWidth; j++)
            {
                float x = (float)i / (float)texWidth;
                float y = ((float)j / (float)texHeight);
                float noise = 1.0f;
                if (currentNoiseType == NoiseType.Simplex)
                {
                    noise = simplexNoise.CalcPixel2D(i, j, 1.0f);
                }
                else
                {
                    noise = Mathf.Clamp(Mathf.PerlinNoise(x * planet.settings.planetRadius, y * planet.settings.planetRadius), 0.0f, 1.0f);
                }
                Color baseColor = planet.settings.gradient.colorKeys[0].color;
                texture.SetPixel(i, j, new Color(noise * baseColor.r, noise * baseColor.g, noise * baseColor.b, 1.0f));
            }
        }
        texture.Apply();
    }

    public void onTypeChange(int value)
    {
        if (value == 0)
        {
            currentNoiseType = NoiseType.Perlin;
        }
        else if (value == 1)
        {
            currentNoiseType = NoiseType.Simplex;
        }
        regenerateTexture();
    }

    public void onScaleChange(float value)
    {
        planet.settings.planetRadius = value;
        scaleText.text = value.ToString("0.0");
        regenerateTexture();
    }

    public void onRadiusChange(float value)
    {
        planet.settings.planetRadius = value;
        radiusText.text = value.ToString("0.0");
        planet.GenerateMesh();
        planet.GenerateColors();
    }

    public void onBaseStrengthChange(float value)
    {
        planet.settings.noiseSettings[0].strength = value;
        baseStrengthLabel.text = value.ToString("0.0");
        planet.GenerateMesh();
        planet.GenerateColors();
    }
    public void onBaseFrequencyChange(float value)
    {
        planet.settings.noiseSettings[0].baseRoughness = value;
        baseFrequencyLabel.text = value.ToString("0.0");
        planet.GenerateMesh();
        planet.GenerateColors();
    }

    public void onBaseDetailChange(float value)
    {
        planet.settings.noiseSettings[0].numLayers = (int) value;
        baseDetailLabel.text = value.ToString("0.0");
        planet.GenerateMesh();
        planet.GenerateColors();
    }

    public void onBaseDetailFrequencyChange(float value)
    {
        planet.settings.noiseSettings[0].roughness = value;
        baseDetailFrequencyLabel.text = value.ToString("0.0");
        planet.GenerateMesh();
        planet.GenerateColors();
    }

    public void onBaseAmplitudeChange(float value)
    {
        planet.settings.noiseSettings[0].persistance = value;
        baseAmplitudeLabel.text = value.ToString("0.0");
        planet.GenerateMesh();
        planet.GenerateColors();
    }

    public void onBaseColorChange(Color color)
    {
        planet.settings.gradient.colorKeys[0].color = color;
        planet.GenerateColors();
    }

    public void onAtmosphereReflectivityChange(float value)
    {
        meshRenderer.material.SetFloat("_Glossiness", value);
    }

    public void onAtmosphereDensityChange(float value)
    {
        meshRenderer.material.SetFloat("_Metallic", value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
