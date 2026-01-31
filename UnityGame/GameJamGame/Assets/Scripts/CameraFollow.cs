using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smooth = 10f;

    void LateUpdate()
    {
        if (!target) return;

        Vector3 desired = new Vector3(target.position.x, target.position.y, -10f);
        transform.position = Vector3.Lerp(transform.position, desired, smooth * Time.deltaTime);
    }
}