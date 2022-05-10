using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButtonScript : MonoBehaviour
{
    public GameObject settingsCanvas;
    
    void Start(){
        settingsCanvas.SetActive(false);
    }
    public void showSettings(){
        if(settingsCanvas.activeSelf){
            settingsCanvas.SetActive(false);
        }else{
            settingsCanvas.SetActive(true);
        }
    }
}
