using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1;
    private int scene3Index = 2, scene4Index = 3;
    void Update()
    {
        
    }
    public void LoadNextScene(){
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void TextGenScene(){
        StartCoroutine(LoadScene(1));
    }
    public void MainScene(){
        StartCoroutine(LoadScene(0));
    }
    public void Scene3Scene(){
        StartCoroutine(LoadScene(scene3Index));
    }
    public void Scene4Scene(){
        StartCoroutine(LoadScene(scene4Index));
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
