using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VelocityMassChanger : MonoBehaviour
{
    public TMP_InputField x_vel, y_vel, z_vel, massInput;
    public Toggle orbitToggle;

    private void Start()
    {
        PlanetariumControl.Instance.velocityMassChanger = this;
    }

    public void onXVelocityChange(string value)
    {
        float newVel = float.Parse(value);
        if (PlanetariumControl.Instance.selectedPlanet is not null)
        {
            Body body = PlanetariumControl.Instance.selectedPlanet.GetComponent<Body>();
            body.UpdateVelocityX(newVel);
        }
    }
    public void onYVelocityChange(string value)
    {
        float newVel = float.Parse(value);
        if (PlanetariumControl.Instance.selectedPlanet is not null)
        {
            Body body = PlanetariumControl.Instance.selectedPlanet.GetComponent<Body>();
            body.UpdateVelocityY(newVel);
        }
    }
    public void onZVelocityChange(string value)
    {
        float newVel = float.Parse(value);
        if (PlanetariumControl.Instance.selectedPlanet is not null)
        {
            Body body = PlanetariumControl.Instance.selectedPlanet.GetComponent<Body>();
            body.UpdateVelocityZ(newVel);
        }
    }

    public void onMassInputChange(string value)
    {
        float newMass = float.Parse(value);
        if (PlanetariumControl.Instance.selectedPlanet is not null)
        {
            Body body = PlanetariumControl.Instance.selectedPlanet.GetComponent<Body>();
            body.Mass = newMass;
        }
    }

    public void onShowOrbitChange(bool value)
    {
        if (PlanetariumControl.Instance.selectedPlanet is not null)
        {
            Body body = PlanetariumControl.Instance.selectedPlanet.GetComponent<Body>();
            body.EnabledOrbitVisual = value;
        }
    }

    public void updateDisplayedValues()
    {
        Body body = PlanetariumControl.Instance.selectedPlanet.GetComponent<Body>();
        x_vel.text = body.getXVelocity().ToString();
        y_vel.text = body.getYVelocity().ToString();
        z_vel.text = body.getZVelocity().ToString();
        massInput.text = body.Mass.ToString();
        orbitToggle.isOn = body.EnabledOrbitVisual;
    }
}