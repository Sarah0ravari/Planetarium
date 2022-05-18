using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGUI : MonoBehaviour
{
    private bool PGUI = false;
    public Canvas editPlantCanvas;
    void Start(){
        editPlantCanvas.enabled = false;
    }
    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0)){
            if(editPlantCanvas.enabled == false){
                editPlantCanvas.enabled = true;
            }else{
                editPlantCanvas.enabled = false;
            }
        }
    }
}
