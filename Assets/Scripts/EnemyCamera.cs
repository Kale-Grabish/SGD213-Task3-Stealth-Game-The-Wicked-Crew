using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EnemyCamera : MonoBehaviour, IDetection
{
    public float timer = 0f;
    public float maxTime = 1.5f;
    public Material AlarmColour;
    public Material CalmColour;
    private SceneLoader sceneLoader;

    public void Alert()
    {
        // Resets the player once the timer has reached 5 seconds. Otherwise it continues counting upwards. Sets the colour of the collision to red.
        if (timer <= maxTime)
        {
            gameObject.GetComponent<Renderer>().material = AlarmColour;
            timer += Time.deltaTime;

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
        // resets timer to 0 and changes the collision colour to white.
        timer = 0f;
        gameObject.GetComponent<Renderer>().material = CalmColour;
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
