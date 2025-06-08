using UnityEngine;

// Created by Ned Tanner

public class LevelChangeTrigger : MonoBehaviour
{
    private SceneLoader sceneLoader;

    public int levelIndex;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sceneLoader = other.GetComponent<SceneLoader>();

            sceneLoader.LoadScene(levelIndex);
        }
    }
}
