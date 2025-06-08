using UnityEngine;

// Created by Kale Grabish

public class Box : Interactable
{
    [Header("Box Settings")]
    public Transform exitPoint;
    public bool isOccupied = false;

    public override void OnInteraction()
    {
        if (!isOccupied)
        {
            EnterExit(true);
        }
        else
        {
            EnterExit(false);
        }
    }

    private void EnterExit(bool entering)
    {
        PlayerMovement player = FindFirstObjectByType<PlayerMovement>();

        if (player != null)
        {
            isOccupied = !entering;
            PlayerMovement controller = player.GetComponent<PlayerMovement>();
            controller.EnterExitBox(this, entering, exitPoint.position);
        }
    }
}