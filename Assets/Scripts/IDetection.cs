using UnityEngine;
// Created by Xaviera Allingham
public interface IDetection
{
    void OnTriggerEnter(Collider other);
    void Calm();
    void Alert();
}
