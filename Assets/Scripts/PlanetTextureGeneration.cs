using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTextureGeneration : MonoBehaviour
{
    public GameObject sphere;
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

    private float scale = 50.0f;
    private float redChannel = 1.0f;
    private float greenChannel = 1.0f;
    private float blueChannel = 1.0f;

    private Texture2D texture;

    int texWidth = 512, texHeight = 512;
    // Start is called before the first frame update
    void Start()
    {
        texture = new Texture2D(texWidth, texHeight, TextureFormat.ARGB32, false);

        regenerateTexture();

        meshRenderer = sphere.GetComponent<MeshRenderer>();
        meshRenderer.material = material;
        meshRenderer.material.SetTexture("_BumpMap", texture);
        meshRenderer.material.mainTexture = texture;
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
                    noise = Mathf.Clamp(Mathf.PerlinNoise(x * scale, y * scale), 0.0f, 1.0f);
                }
                texture.SetPixel(i, j, new Color(noise * redChannel, noise * greenChannel, noise * blueChannel, 1.0f));
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
        scale = value;
        scaleText.text = value.ToString("0.00");
        regenerateTexture();
    }

    public void onRedColorChange(float value)
    {
        redChannel = value;
        regenerateTexture();
    }

    public void onGreenColorChange(float value)
    {
        greenChannel = value;
        regenerateTexture();
    }

    public void onBlueColorChange(float value)
    {
        blueChannel = value;
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
