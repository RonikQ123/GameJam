using UnityEngine;
using System;

public class MaskManager : MonoBehaviour
{
    public static MaskManager Instance { get; private set; }

    public int CurrentMask { get; private set; } = 0; // 0 = none/normal
    public event Action<int> OnMaskChanged;

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void EquipMask(int maskId)
    {
        if (maskId == CurrentMask) return;
        CurrentMask = maskId;
        OnMaskChanged?.Invoke(CurrentMask);
    }
}
