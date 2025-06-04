using UnityEngine;

public class Box : Interactable
{
    [Header("Box Settings")]
    public Transform exitPoint;
    private bool isOccupied = false;

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
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            isOccupied = !entering;
            PlayerMovement controller = player.GetComponent<PlayerMovement>();
            controller.EnterExitBox(this, entering, exitPoint.position);
        }
    }
}