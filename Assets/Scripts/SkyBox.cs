using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBox : MonoBehaviour
{
    // Start is called before the first frame update
    public Material skyboxSpace, skyboxBright, skyboxDRed, skyboxNRed, skyboxDOrange, skyboxDGreen, skyboxDGreenBlue, skyboxNBlue1, skyboxNBlue2, skyboxNBluePink, skyboxMilky;
    public GameObject Panel1, Panel2, xButton;

    void Start(){
        Panel1.SetActive(true);
        Panel2.SetActive(false);
        xButton.SetActive(false);
    }
    public void ChangeSolarClick(){
        Panel1.SetActive(false);
        Panel2.SetActive(true);
        xButton.SetActive(true);
    }
    public void ChangeMilky(){
        RenderSettings.skybox = skyboxMilky;
    }
    public void ChangeNBP(){
        RenderSettings.skybox = skyboxNBluePink;
    }
    public void ChangeNB1(){
        RenderSettings.skybox = skyboxNBlue1;
    }
    public void ChangeNB2(){
        RenderSettings.skybox = skyboxNBlue2;
    }
    public void ChangeDGB(){
        RenderSettings.skybox = skyboxDGreenBlue;
    }
    public void ChangeDG(){
        RenderSettings.skybox = skyboxDGreen;
    }
    public void ChangeDO(){
        RenderSettings.skybox = skyboxDOrange;
    }
    public void ChangeNRY(){
        RenderSettings.skybox = skyboxNRed;
    }
    public void ChangeDR(){
        RenderSettings.skybox = skyboxDRed;
    }
    public void ChangeDSB(){
        RenderSettings.skybox = skyboxBright;
    }
    public void ChangeDS(){
        RenderSettings.skybox = skyboxSpace;
    }
    public void XClick(){
        Panel2.SetActive(false);
        xButton.SetActive(false);
        Panel1.SetActive(true);
    }
}
