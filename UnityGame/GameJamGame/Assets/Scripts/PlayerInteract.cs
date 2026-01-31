using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private IInteractable current;

    void Update()
    {
        if (current != null && Input.GetKeyDown(KeyCode.E))
        {
            current.Interact();
        }
    }

    // Called by interactables when player enters/exits their trigger
    public void SetCurrent(IInteractable interactable) => current = interactable;
    public void ClearCurrent(IInteractable interactable)
    {
        if (current == interactable) current = null;
    }
}