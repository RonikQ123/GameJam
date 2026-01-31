using UnityEngine;

public class PlayerMask : MonoBehaviour
{
    [SerializeField] private MaskId currentMask = MaskId.None;
    public MaskId CurrentMask => currentMask;

    public void Equip(MaskId mask)
    {
        currentMask = mask;
        Debug.Log($"Equipped mask: {currentMask}");
    }

    public void DropMask()
    {
        currentMask = MaskId.None;
        Debug.Log("Dropped mask");
    }
}
