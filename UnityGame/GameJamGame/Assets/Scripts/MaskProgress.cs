using UnityEngine;

public class MaskProgress : MonoBehaviour
{
    [Header("Shard Progress")]
    [SerializeField] private int totalShardsNeeded = 3;
    private bool[] shardsCollected;
    public int CollectedCount { get; private set; }

    public bool OrchidUnlocked => CollectedCount >= totalShardsNeeded;

    private void Awake()
    {
        shardsCollected = new bool[totalShardsNeeded];
        CollectedCount = 0;
    }

    // shardIndex: 0..totalShardsNeeded-1
    public void CollectShard(int shardIndex)
    {
        if (shardIndex < 0 || shardIndex >= shardsCollected.Length) return;
        if (shardsCollected[shardIndex]) return; // already collected

        shardsCollected[shardIndex] = true;
        CollectedCount++;

        Debug.Log($"Shard collected {CollectedCount}/{totalShardsNeeded}");

        if (OrchidUnlocked)
            Debug.Log("ORCHID MASK UNLOCKED!");
    }
}
