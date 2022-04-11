using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTextureGeneration : MonoBehaviour
{
    public Material material;

    private float scale = 50.0f;

    private Texture2D texture;

    int texWidth = 512, texHeight = 512;
    // Start is called before the first frame update
    void Start()
    {
        texture = new Texture2D(256, 256, TextureFormat.ARGB32, false);

        generateTexture();

        var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = Vector3.one * 6.0f;
        var sphereMeshRen = sphere.GetComponent<MeshRenderer>();
        sphereMeshRen.material = material;
        sphereMeshRen.material.mainTexture = texture;


    }

    void generateTexture()
    {
        for (int i = 0; i < 256; i++)
        {
            for (int j = 0; j < 256; j++)
            {
                float x = (float)i / (float)texWidth;
                float y = ((float)j / (float)texHeight);
                float noise = Mathf.Clamp(Mathf.PerlinNoise(x * scale, y * scale), 0.0f, 1.0f);
                texture.SetPixel(i, j, new Color(noise, noise, 0.5f, 1.0f));
            }
        }
        texture.Apply();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
