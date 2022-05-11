using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManger : MonoBehaviour
{
    public void Button(string solar){
        SceneManager.LoadScene(solar);
    }
    public void Button1(string simulation) {  
        SceneManager.LoadScene(simulation);  
    }  
    public void Button2() {  
        Application.Quit(); 
    }
}
