using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Created by Ned Tanner

public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScreen;

    public void LoadScene(int sceneId)
    {
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    public IEnumerator LoadSceneAsync(int sceneId)
    {
        // A modular scene index goes into this, so this can work on a main menu or pause menu too if you want to reuse it
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            // Ends the loading sequence once the level is fully loaded
            yield return null;
        }
    }    
}
