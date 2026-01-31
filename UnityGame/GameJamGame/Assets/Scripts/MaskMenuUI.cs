using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MaskMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject panelRoot;
    [SerializeField] private Button dropMaskButton;
    [SerializeField] private TextMeshProUGUI currentMaskText;

    [SerializeField] private MaskProgress progress;
    [SerializeField] private Button orchidButton;


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
        isOpen = true;

        panelRoot.SetActive(true);
        RefreshLabel();

        if (orchidButton != null && progress != null)
            orchidButton.interactable = progress.OrchidUnlocked;
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
