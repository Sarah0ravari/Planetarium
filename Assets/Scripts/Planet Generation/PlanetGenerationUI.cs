using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlanetGenerationUI : MonoBehaviour
{
    private Planet planet;
    public Material planetMaterial;
    public Material atmosphereMaterial;
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

    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = new GameObject();
        obj.name = "Planet" + Random.Range(0, 999).ToString();
        planet = obj.AddComponent<Planet>();
        planet.material = this.planetMaterial;
        planet.atmosphereMaterial = this.atmosphereMaterial;

        var viewControls = Camera.main.GetComponent<GlobeViewControls>();
        viewControls.globe = obj.transform;
    }

    public void onScaleChange(float value)
    {
        planet.settings.planetRadius = value;
        scaleText.text = value.ToString("0.0");
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
        if (planet is null) return;

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
        if (planet is null) return;

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
        if (planet is null) return;

        planet.settings.colorKeys[2].color = color;
        planet.settings.gradient.SetKeys(planet.settings.colorKeys, planet.settings.alphaKeys);
        planet.GenerateColors();
    }

    public void onRandomize()
    {
        planet.Randomize(this);
    }

    public void onCreate()
    {
        PlanetariumControl.Instance.newPlanet = planet;
        SceneManager.LoadScene(1);
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
