using UnityEngine;

public class Camera: MonoBehaviour {
    public Transform target;
    public Vector3 offset = new Vector3(0, 5, -10); // Adjust to position camera behind player
    public float smoothSpeed = 0.125f;

    void LateUpdate() {
        // LateUpdate ensures the player finishes moving before the camera follows
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(target); // Keeps camera pointed at the player
    }
}
