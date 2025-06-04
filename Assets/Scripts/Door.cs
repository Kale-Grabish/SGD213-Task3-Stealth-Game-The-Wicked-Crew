using UnityEngine;
using System.Collections;

public class Door : Interactable
{
    [Header("Door Settings")]
    public float rotationAngle = 90f;  // Degrees to rotate
    public float openSpeed = 2f;
    private bool isOpen = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;

    private void Start()
    {
        // Store initial rotation
        closedRotation = transform.rotation;
        // Calculate open rotation (rotates around Y axis)
        openRotation = transform.rotation * Quaternion.Euler(0f, rotationAngle, 0f);
    }

    public override void OnInteraction()
    {
        OpenClose();
    }

    private void OpenClose()
    {
        isOpen = !isOpen;
        StartCoroutine(RotateDoor());
    }

    private IEnumerator RotateDoor()
    {
        Quaternion targetRotation = isOpen ? openRotation : closedRotation;
        Quaternion startRotation = transform.rotation;
        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * openSpeed;
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime);
            yield return null;
        }
    }
}