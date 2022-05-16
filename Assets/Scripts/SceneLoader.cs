using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1;

    private void Awake()
    {
        if (PlanetariumControl.Instance is null)
        {
            GameObject go = new GameObject();
            PlanetariumControl pc = go.AddComponent<PlanetariumControl>();
        }
    }
    void Update()
    {
        
    }
    //Build Settings Scenes: 0Menu 1Main 2Simulation 3Solar
    public void LoadNextScene(){
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void TextGenScene(){
        StartCoroutine(LoadScene(2));
    }
    public void MainScene(){
        StartCoroutine(LoadScene(1));
    }
    public void MenuScene(){
        StartCoroutine(LoadScene(0));
    }
    public void SolarScene(){
        StartCoroutine(LoadScene(3));
    }

    IEnumerator LoadScene(int sceneIndex){
        //Play animation
        transition.SetTrigger("Start");
        //Wait
        yield return new WaitForSeconds(transitionTime);
        //Load Scene
        SceneManager.LoadScene(sceneIndex);

    }
}
