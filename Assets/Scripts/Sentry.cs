using UnityEngine;

public class Sentry : MonoBehaviour, IDetection
{
    public float timer = 0f;
    public float maxTime = 5f;
    public void Alert()
    {
        if (timer <= maxTime)
        {
            timer += Time.deltaTime;

            if (timer >= maxTime)
            {
                Debug.Log("Max time reached");
                // destroy player
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
    }
}
