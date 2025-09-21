using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smooth = 0.2f;
    public float minY = 0f;
    Vector3 vel;

    void LateUpdate()
    {
        if (player == null) return;
        float targetY = Mathf.Max(minY, player.position.y);
        Vector3 target = new Vector3(transform.position.x, targetY, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, target, ref vel, smooth);
    }
}