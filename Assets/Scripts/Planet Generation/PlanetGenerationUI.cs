using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGenerationUI : MonoBehaviour
{
    public Planet planet;
    public Material material;
    public TMPro.TextMeshProUGUI scaleText;

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

        //meshRenderer = sphere.GetComponent<MeshRenderer>();
        //meshRenderer.material = material;
        //meshRenderer.material.SetTexture("_BumpMap", texture);
        //meshRenderer.material.mainTexture = texture;
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
                texture.SetPixel(i, j, new Color(noise * planet.settings.planetColor.r, noise * planet.settings.planetColor.g, noise * planet.settings.planetColor.b, 1.0f));
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
        scaleText.text = value.ToString("0.00");
        regenerateTexture();
    }

    public void onRedColorChange(float value)
    {
        planet.settings.planetColor.r = value;
        planet.GenerateColors();
        regenerateTexture();
    }

    public void onGreenColorChange(float value)
    {
        planet.settings.planetColor.g = value;
        planet.GenerateColors();
        regenerateTexture();
    }

    public void onBlueColorChange(float value)
    {
        planet.settings.planetColor.b = value;
        planet.GenerateColors();
        regenerateTexture();
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
