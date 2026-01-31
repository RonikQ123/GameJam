using UnityEngine;

public class Podium : MonoBehaviour
{
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    [SerializeField] private MaskMenuUI maskMenuUI;
    [SerializeField] private PromptUI promptUI;

    private PlayerMask playerInRange;

    private void Update()
    {
        if (playerInRange == null || maskMenuUI == null) return;

        if (Input.GetKeyDown(interactKey))
        {
            if (maskMenuUI.IsOpen) maskMenuUI.Close();
            else maskMenuUI.Open(playerInRange);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var pm = other.GetComponent<PlayerMask>();
        if (pm == null) return;

        playerInRange = pm;

        if (promptUI != null)
            promptUI.Show("Press E");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var pm = other.GetComponent<PlayerMask>();
        if (pm == null || pm != playerInRange) return;

        playerInRange = null;

        if (promptUI != null)
            promptUI.Hide();

        if (maskMenuUI != null && maskMenuUI.IsOpen)
            maskMenuUI.Close();
    }
}
