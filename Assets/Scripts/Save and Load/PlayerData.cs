using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
[System.Serializable] //allows us to save this into a file
public class PlayerData : MonoBehaviour
{
    public int level;
    public int health;
    public float[] position;
    public Material skybox;

    //player is a reference to a script containing this data - most likely will be referencing Planet script
    public PlayerData (Player player){
        //all the data to be saved - will be changed to planets, their locations, and their attributes
        level = player.level;
        health = player.health;

        //we cant save a Vector3, so instead we save an array containing the x, y, and z positions
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        //saving the skybox
        skybox = RenderSettings.skybox;
    }
}
*/

/*
//attributes and methods to be copied to Script containing data to be saved(currently Player script)
public int level = 2;
public int health = 40;

public void SavePlayer(){
    SaveSystem.SavePlayer(this);
}

public void LoadPlayer(){
    PlayerData data = SaveSystem.LoadPlayer();

    level = data.level;
    health = data.health;

    //recreating position with int array
    Vector3 position;
    position.x = data.position[0];
    position.y = data.position[1];
    position.z = data.position[2];
    transform.position = position;
}
*/