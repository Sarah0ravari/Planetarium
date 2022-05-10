using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadButtonManager : MonoBehaviour
{
    public GameObject Panel1, SavePanel, xButton;

    void Start(){
        Panel1.SetActive(true);
        SavePanel.SetActive(false);
        xButton.SetActive(false);
    }
    public void ChangeSaveHUD(){
        Panel1.SetActive(false);
        SavePanel.SetActive(true);
        xButton.SetActive(true);
    }
    public void XClick(){
        SavePanel.SetActive(false);
        xButton.SetActive(false);
        Panel1.SetActive(true);
    }
}
