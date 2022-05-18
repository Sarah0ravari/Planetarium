using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedMass : MonoBehaviour
{
    public Slider xSlider, ySlider, zSlider, massSlider;
    // Start is called before the first frame update
    void Start()
    {
        xSlider.minValue = 0;
        xSlider.maxValue = 100;
        xSlider.wholeNumbers = true;
        ySlider.minValue = 0;
        ySlider.maxValue = 100;
        ySlider.wholeNumbers = true;
        zSlider.minValue = 0;
        zSlider.maxValue = 100;
        zSlider.wholeNumbers = true;
        massSlider.minValue = 10;
        massSlider.maxValue = 100;
        massSlider.wholeNumbers = true;
    }
}
