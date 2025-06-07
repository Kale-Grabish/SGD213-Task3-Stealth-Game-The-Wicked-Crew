using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Annoying that I need to make a whole script just for this little issue, though more scripts can be added here when Main Menu needs further customisation
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
