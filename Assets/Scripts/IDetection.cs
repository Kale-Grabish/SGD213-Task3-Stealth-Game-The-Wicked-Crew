using UnityEngine;

public interface IDetection
{
    void OnTriggerEnter(Collider other);
    void Calm();
    void Alert();
}
