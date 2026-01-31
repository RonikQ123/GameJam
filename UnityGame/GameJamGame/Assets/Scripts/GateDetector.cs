using UnityEngine;

public class GateDetector : MonoBehaviour
{
    private IslandGate gate;

    [SerializeField] private PromptUI promptUI;

    private void Awake()
    {
        gate = GetComponentInParent<IslandGate>();
        if (gate == null)
            Debug.LogError("GateDetector must be a child of an object with IslandGate.");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var pm = other.GetComponent<PlayerMask>();
        if (pm == null) return;

        bool allowed = gate.Evaluate(pm); // we’ll modify Evaluate() to return allowed

        if (!allowed && promptUI != null)
            promptUI.Show($"You need the {gate.RequiredMaskName()} mask");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        var pm = other.GetComponent<PlayerMask>();
        if (pm == null) return;

        bool allowed = gate.Evaluate(pm);

        if (promptUI != null)
        {
            if (!allowed) promptUI.Show($"You need the {gate.RequiredMaskName()} mask");
            else promptUI.Hide();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var pm = other.GetComponent<PlayerMask>();
        if (pm == null) return;

        gate.Relock();

        if (promptUI != null)
            promptUI.Hide();
    }
}
