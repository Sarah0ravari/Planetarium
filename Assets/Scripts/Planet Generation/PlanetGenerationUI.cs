using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetGenerationUI : MonoBehaviour
{
    public Planet planet;
    public Material material;
    public TMPro.TextMeshProUGUI scaleText;
    public TMPro.TextMeshProUGUI radiusText;

    [Header("Base")]
    public TMPro.TextMeshProUGUI baseStrengthLabel;
    public Slider baseStrengthSlider;
    public TMPro.TextMeshProUGUI baseFrequencyLabel;
    public Slider baseFrequencySlider;
    public TMPro.TextMeshProUGUI baseDetailLabel;
    public Slider baseDetailSlider;
    public TMPro.TextMeshProUGUI baseDetailFrequencyLabel;
    public Slider baseDetailFrequencySlider;
    public TMPro.TextMeshProUGUI baseAmplitudeLabel;
    public Slider baseAmplitudeSlider;
    public FlexibleColorPicker baseColor;

    [Header("Mid")]
    public TMPro.TextMeshProUGUI midStrengthLabel;
    public Slider midStrengthSlider;
    public TMPro.TextMeshProUGUI midFrequencyLabel;
    public Slider midFrequencySlider;
    public TMPro.TextMeshProUGUI midDetailLabel;
    public Slider midDetailSlider;
    public TMPro.TextMeshProUGUI midDetailFrequencyLabel;
    public Slider midDetailFrequencySlider;
    public TMPro.TextMeshProUGUI midAmplitudeLabel;
    public Slider midAmplitudeSlider;
    public FlexibleColorPicker midColor;

    [Header("Top")]
    public TMPro.TextMeshProUGUI topStrengthLabel;
    public Slider topStrengthSlider;
    public TMPro.TextMeshProUGUI topFrequencyLabel;
    public Slider topFrequencySlider;
    public TMPro.TextMeshProUGUI topDetailLabel;
    public Slider topDetailSlider;
    public TMPro.TextMeshProUGUI topDetailFrequencyLabel;
    public Slider topDetailFrequencySlider;
    public TMPro.TextMeshProUGUI topAmplitudeLabel;
    public Slider topAmplitudeSlider;
    public FlexibleColorPicker topColor;

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
        planet.settings.colorKeys[0].color = color;
        planet.settings.gradient.SetKeys(planet.settings.colorKeys, planet.settings.alphaKeys);
        planet.GenerateColors();
    }

    /**
     * Middle
     */
    public void onMidStrengthChange(float value)
    {
        planet.settings.noiseSettings[1].strength = value;
        midStrengthLabel.text = value.ToString("0.0");
        planet.GenerateMesh();
        planet.GenerateColors();
    }

    public void onMidFrequencyChange(float value)
    {
        planet.settings.noiseSettings[1].baseRoughness = value;
        midFrequencyLabel.text = value.ToString("0.0");
        planet.GenerateMesh();
        planet.GenerateColors();
    }

    public void onMidDetailChange(float value)
    {
        planet.settings.noiseSettings[1].numLayers = (int) value;
        midDetailLabel.text = value.ToString("0.0");
        planet.GenerateMesh();
        planet.GenerateColors();
    }

    public void onMidDetailFrequencyChange(float value)
    {
        planet.settings.noiseSettings[1].roughness = value;
        midDetailFrequencyLabel.text = value.ToString("0.0");
        planet.GenerateMesh();
        planet.GenerateColors();
    }

    public void onMidAmplitudeChange(float value)
    {
        planet.settings.noiseSettings[1].persistance = value;
        midAmplitudeLabel.text = value.ToString("0.0");
        planet.GenerateMesh();
        planet.GenerateColors();
    }

    public void onMidColorChange(Color color)
    {
        planet.settings.colorKeys[1].color = color;
        planet.settings.gradient.SetKeys(planet.settings.colorKeys, planet.settings.alphaKeys);
        planet.GenerateColors();
    }

    /**
     * Top
     */
    public void onTopStrengthChange(float value)
    {
        planet.settings.noiseSettings[2].strength = value;
        topStrengthLabel.text = value.ToString("0.0");
        planet.GenerateMesh();
        planet.GenerateColors();
    }

    public void onTopFrequencyChange(float value)
    {
        planet.settings.noiseSettings[2].baseRoughness = value;
        topFrequencyLabel.text = value.ToString("0.0");
        planet.GenerateMesh();
        planet.GenerateColors();
    }

    public void onTopDetailChange(float value)
    {
        planet.settings.noiseSettings[2].numLayers = (int) value;
        topDetailLabel.text = value.ToString("0.0");
        planet.GenerateMesh();
        planet.GenerateColors();
    }

    public void onTopDetailFrequencyChange(float value)
    {
        planet.settings.noiseSettings[2].roughness = value;
        topDetailFrequencyLabel.text = value.ToString("0.0");
        planet.GenerateMesh();
        planet.GenerateColors();
    }

    public void onTopAmplitudeChange(float value)
    {
        planet.settings.noiseSettings[2].persistance = value;
        topAmplitudeLabel.text = value.ToString("0.0");
        planet.GenerateMesh();
        planet.GenerateColors();
    }

    public void onTopColorChange(Color color)
    {
        planet.settings.colorKeys[2].color = color;
        planet.settings.gradient.SetKeys(planet.settings.colorKeys, planet.settings.alphaKeys);
        planet.GenerateColors();
    }

    public void onRandomize()
    {
        planet.Randomize(this);
    }

    /*
     * Atmosphere
     */
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
