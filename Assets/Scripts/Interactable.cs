using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [Header("Interaction Settings")]
    public float interactRange = 2f;
    public Transform interactionPoint;

    protected bool isInteracting = false;

    public virtual void OnInteraction()
    {
        // Called when player interacts with this object
    }

    public virtual void UpdateInteraction()
    {
        // Update interaction state
    }
}