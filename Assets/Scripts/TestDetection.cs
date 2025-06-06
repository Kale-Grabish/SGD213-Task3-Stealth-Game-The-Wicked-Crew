using UnityEngine;
using UnityEngine.SceneManagement;

public class TestDetection : MonoBehaviour, IDetection
{
    public float timer = 0f;
    public float maxTime = 5f;

    private SceneLoader sceneLoader;

    public void Alert()
    {
        if (timer <= maxTime)
        {
            timer += Time.deltaTime;

            if (timer >= maxTime)
            {
                Debug.Log("Max time reached");


                // Reloads current scene with a loading screen, not that useful for the prototype
                // but it'd give a more complex game an extra layer of polish
                sceneLoader.LoadScene((SceneManager.GetActiveScene().buildIndex));


            }
        }

    }

    public void Calm()
    {
        timer = 0f;
        Debug.Log("timer reset");
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision detected");

        if (other.gameObject.CompareTag("Player"))
        {
            sceneLoader = other.GetComponent<SceneLoader>();
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Alert();

            
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Calm();
            
        }
    }
}
