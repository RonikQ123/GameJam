using UnityEngine;

public class IslandGate : MonoBehaviour
{
    [SerializeField] private MaskId requiredMask = MaskId.None;

    private Collider2D solidCollider;

    private void Awake()
    {
        solidCollider = GetComponent<Collider2D>();
        if (solidCollider == null)
            Debug.LogError("IslandGate needs a Collider2D on the same GameObject.");
    }

    public bool Evaluate(PlayerMask pm)
    {
        if (pm == null || solidCollider == null) return false;

        bool allowed = (pm.CurrentMask == requiredMask);
        solidCollider.enabled = !allowed; // allowed -> disable wall
        return allowed;
    }

    public void Relock()
    {
        if (solidCollider != null)
            solidCollider.enabled = true;
    }

    public string RequiredMaskName()
    {
        return requiredMask.ToString();
    }
}
