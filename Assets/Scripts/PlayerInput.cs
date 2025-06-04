using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private float interactRange = 2f;

    // Allows other scripts access these variables without cluttering the inspector with public variable stuff :)
    // ... existing properties ... stinky, smelly properties ...
    public Vector2 MoveInput { get; private set; }
    public Vector2 LookInput { get; private set; }
    public float crouchCooldown = 0.3f;

    private float lastToggleTime = -Mathf.Infinity;
    private Animator playerAnimator;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        MoveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        LookInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        // Cooldown helps prevent buggy animations and general jank
        if (Input.GetKey(KeyCode.LeftControl) && Time.time >= lastToggleTime + crouchCooldown)
        {
            playerMovement.Crouch();
            lastToggleTime = Time.time;
        }

        LeanCheck();
        HandleInteraction();
    }

    void LeanCheck()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            playerAnimator.SetBool("IsLeaningLeft", true);
            playerAnimator.SetBool("IsLeaningRight", false);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            playerAnimator.SetBool("IsLeaningRight", true);
            playerAnimator.SetBool("IsLeaningLeft", false);
        }
        else
        {
            playerAnimator.SetBool("IsLeaningLeft", false);
            playerAnimator.SetBool("IsLeaningRight", false);
        }
    }

    private void HandleInteraction()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider hit in hits)
            {
                Interactable interactable = hit.GetComponent<Interactable>();
                if (interactable != null)
                {
                    interactable.OnInteraction();
                    break;
                }
            }
        }
    }
}