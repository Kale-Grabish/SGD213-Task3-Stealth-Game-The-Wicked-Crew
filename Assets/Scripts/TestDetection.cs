using UnityEngine;

public class TestDetection : MonoBehaviour, IDetection
{
    public void Alert()
    {

    }

    public void Calm()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision detected");
    }
}
