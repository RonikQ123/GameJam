using UnityEngine;

public class MaskShardCollectible : MonoBehaviour
{
    [SerializeField] private int shardIndex = 0; // 0,1,2...
    [SerializeField] private MaskProgress progress;

    private void Reset()
    {
        // Auto-assign if possible in editor
        if (progress == null)
            progress = Object.FindAnyObjectByType<MaskProgress>();
    }

    private void Awake()
    {
        if (progress == null)
            progress = Object.FindAnyObjectByType<MaskProgress>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        progress.CollectShard(shardIndex);
        gameObject.SetActive(false); // hide/remove shard
    }
}
