using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SentryDetection : MonoBehaviour, IDetection
{
    public float timer = 0f;
    public float maxTime = 1.5f;
    public GameObject alarmedStatus;
    private SceneLoader sceneLoader;

    private void Start()
    {
        Calm();
    }

    public void Alert()
    {
        
        // Resets the player once the timer has reached 5 seconds. Otherwise it continues counting upwards. 
        if (timer <= maxTime)
        {
            timer += Time.deltaTime;
            // Sets the alarmed text visible
            alarmedStatus.GetComponent<MeshRenderer>().enabled = true;

            if (timer >= maxTime)
            {
                // Reloads current scene with a loading screen, not that useful for the prototype
                // but it'd give a more complex game an extra layer of polish
                sceneLoader.LoadScene((SceneManager.GetActiveScene().buildIndex));


            }
        }

    }


    public void Calm()
    {
        // Resets the timer to 0 and sets the alarmed text invisible
        timer = 0f;
        alarmedStatus.GetComponent<MeshRenderer>().enabled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        // If a player has triggered the collision, it gets the scene loader component.
        if (other.gameObject.CompareTag("Player"))
        {
            sceneLoader = other.GetComponent<SceneLoader>();
        }
    }

    public void OnTriggerStay(Collider other)
    {
        // if a player stays in the collision, runs the Alert function.
        if (other.gameObject.CompareTag("Player"))
        {
            Alert();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        // if a player has exited the collision, runs the Calm function.
        if (other.gameObject.CompareTag("Player"))
        {
            Calm();
        }
    }
}
