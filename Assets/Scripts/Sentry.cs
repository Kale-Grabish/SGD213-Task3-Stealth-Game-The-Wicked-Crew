using UnityEngine;
using UnityEngine.SceneManagement;

public class Sentry : MonoBehaviour, IDetection
{
    public float timer = 0f;
    public float maxTime = 5f;

    private SceneLoader sceneLoader;

    public void Alert()
    {
        // Resets the player once the timer has reached 5 seconds. Otherwise it continues counting upwards.
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
        // resets timer to 0
        timer = 0f;
        Debug.Log("timer reset");
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision detected");
        
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

            Debug.Log(timer);
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
