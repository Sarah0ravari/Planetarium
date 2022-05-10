using UnityEngine;
using System.IO; //used for files - input output
using System.Runtime.Serialization.Formatters.Binary; //allows us to access Binary formatters
/*
public static class SaveSystem
{
    public static void SavePlayer(Player player){
        BinaryFormatter formatter = new BinaryFormatter();
        //where the file will be saved
        string path = Application.persistentDataPath + "/solarsystem.doc";
        //this creates the file with the given path
        FileStream stream = new FileStream(path, FileMode.Create);

        //write data to file
        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer(){
        //getting the path for the file
        string path = Application.persistentDataPath + "/solarsystem.doc";
        //check if file exists
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            //changes from binary back to readable format
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }else{
            Debug.LogError("Save File not found in" + path);
        }
}*/