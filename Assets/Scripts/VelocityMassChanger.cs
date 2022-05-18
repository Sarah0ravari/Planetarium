using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VelocityMassChanger : MonoBehaviour
{
    public TMP_InputField x_vel, y_vel, z_vel, massInput;
    public Toggle orbitToggle;
    bool disableOnChange = false;

    private void Start()
    {
        PlanetariumControl.Instance.velocityMassChanger = this;
    }

    public void onXVelocityChange(string value)
    {
        if (disableOnChange) return;

        try
        {
            float newVel = float.Parse(value);
            if (PlanetariumControl.Instance.selectedPlanet is not null)
            {
                Body body = PlanetariumControl.Instance.selectedPlanet.GetComponent<Body>();
                body.UpdateVelocityX(newVel);
            }
        }
        catch { }
    }
    public void onYVelocityChange(string value)
    {
        if (disableOnChange) return;

        try
        {
            float newVel = float.Parse(value);
            if (PlanetariumControl.Instance.selectedPlanet is not null)
            {
                Body body = PlanetariumControl.Instance.selectedPlanet.GetComponent<Body>();
                body.UpdateVelocityY(newVel);
            }
        }
        catch { }
    }
    public void onZVelocityChange(string value)
    {
        if (disableOnChange) return;

        try
        {
            float newVel = float.Parse(value);
            if (PlanetariumControl.Instance.selectedPlanet is not null)
            {
                Body body = PlanetariumControl.Instance.selectedPlanet.GetComponent<Body>();
                body.UpdateVelocityZ(newVel);
            }
        }
        catch { }
    }

    public void onMassInputChange(string value)
    {
        if (disableOnChange) return;

        try
        {
            float newMass = float.Parse(value);
            if (PlanetariumControl.Instance.selectedPlanet is not null)
            {
                Body body = PlanetariumControl.Instance.selectedPlanet.GetComponent<Body>();
                body.Mass = newMass;
            }
        }
        catch { }
    }

    public void onShowOrbitChange(bool value)
    {
        if (disableOnChange) return;

        if (PlanetariumControl.Instance.selectedPlanet is not null)
        {
            Body body = PlanetariumControl.Instance.selectedPlanet.GetComponent<Body>();
            body.EnabledOrbitVisual = value;
        }
    }

    public void updateDisplayedValues()
    {
        disableOnChange = true;
        Body body = PlanetariumControl.Instance.selectedPlanet.GetComponent<Body>();
        x_vel.text = body.getXVelocity().ToString();
        y_vel.text = body.getYVelocity().ToString();
        z_vel.text = body.getZVelocity().ToString();
        massInput.text = body.Mass.ToString();
        orbitToggle.isOn = body.EnabledOrbitVisual;
        disableOnChange = false;
    }
}