using UnityEngine;
using TMPro;

public class PromptUI : MonoBehaviour
{
    [SerializeField] private GameObject root;       // optional: parent object to toggle
    [SerializeField] private TextMeshProUGUI text;  // your PromptText

    private int showCount = 0;

    private void Awake()
    {
        Hide();
    }

    public void Show(string message)
    {
        showCount = Mathf.Max(showCount, 0) + 1;

        if (root != null) root.SetActive(true);
        if (text != null) text.text = message;
    }

    public void Hide()
    {
        showCount = 0;
        if (text != null) text.text = "";
        if (root != null) root.SetActive(false);
    }

    // Use this when multiple triggers could show prompts at once
    public void Release()
    {
        showCount = Mathf.Max(0, showCount - 1);
        if (showCount == 0) Hide();
    }
}
