using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MaskMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject panelRoot;
    [SerializeField] private Button dropMaskButton;
    [SerializeField] private TextMeshProUGUI currentMaskText;

    [Header("Orchid Unlock")]
    [SerializeField] private MaskProgress progress;
    [SerializeField] private Button orchidButton;
    [SerializeField] private PromptUI promptUI;
    [SerializeField] private string orchidLockedMessage = "You must collect orchid shards";
    [SerializeField] private float messageSeconds = 1.5f;

    private PlayerMask playerMask;
    private bool isOpen;

    private void Awake()
    {
        if (panelRoot != null) panelRoot.SetActive(false);

        if (dropMaskButton != null)
            dropMaskButton.onClick.AddListener(OnDropMaskClicked);
    }

    public void Open(PlayerMask target)
    {
        playerMask = target;
        panelRoot.SetActive(true);
        isOpen = true;

        RefreshLabel();
        RefreshOrchidButton();
    }

    public void Close()
    {
        isOpen = false;
        playerMask = null;
        panelRoot.SetActive(false);
    }

    public bool IsOpen => isOpen;

    public void EquipMask(int maskId)
    {
        if (playerMask == null) return;

        playerMask.Equip((MaskId)maskId);
        RefreshLabel();
        Close();
    }

    // 🔥 Wire the Orchid button to call THIS (not EquipMask)
    public void OnOrchidClicked()
    {
        if (progress != null && !progress.OrchidUnlocked)
        {
            if (promptUI != null)
            {
                promptUI.Show(orchidLockedMessage);
                CancelInvoke(nameof(HidePrompt));
                Invoke(nameof(HidePrompt), messageSeconds);
            }
            return;
        }

        // If unlocked (or progress not set), equip Orchid
        EquipMask((int)MaskId.Orchids);
    }

    private void RefreshOrchidButton()
    {
        if (orchidButton == null) return;

        // Keep it visible so it can be clicked even when locked
        orchidButton.gameObject.SetActive(true);

        // Optional: still allow click even when locked (so message can show)
        orchidButton.interactable = true;

        // Optional: show locked text
        var label = orchidButton.GetComponentInChildren<TextMeshProUGUI>();
        if (label != null && progress != null)
            label.text = progress.OrchidUnlocked ? "Orchid Mask" : "Orchid Mask (Locked)";
    }

    private void HidePrompt()
    {
        if (promptUI != null)
            promptUI.Hide();
    }

    private void OnDropMaskClicked()
    {
        if (playerMask == null) return;

        playerMask.DropMask();
        RefreshLabel();
        Close();
    }

    private void RefreshLabel()
    {
        if (currentMaskText != null && playerMask != null)
            currentMaskText.text = $"Current: {playerMask.CurrentMask}";
    }
}
