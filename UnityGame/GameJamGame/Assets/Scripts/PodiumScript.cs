using UnityEngine;
using TMPro;

public class MaskPodium : MonoBehaviour, IInteractable
{
    public int maskId = 1;

    [Header("Optional Prompt")]
    public GameObject promptObject; // assign "Press E" TMP object here

    private PlayerInteract playerInRange;

    public void Interact()
    {
        if (MaskManager.Instance == null) return;

        MaskManager.Instance.EquipMask(maskId);

        // Optional: feedback
        Debug.Log($"Equipped mask {maskId} from podium {name}");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var pi = other.GetComponent<PlayerInteract>();
        if (pi == null) return;

        playerInRange = pi;
        pi.SetCurrent(this);

        if (promptObject) promptObject.SetActive(true);

        Debug.Log("Podium trigger entered by: " + other.name);


    }

    void OnTriggerExit2D(Collider2D other)
    {
        var pi = other.GetComponent<PlayerInteract>();
        if (pi == null) return;

        if (pi == playerInRange)
        {
            pi.ClearCurrent(this);
            playerInRange = null;
        }

        if (promptObject) promptObject.SetActive(false);
    }
}
