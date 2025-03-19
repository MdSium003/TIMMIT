using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero; // Current velocity of the camera

    [Range(0, 1)]
    public float smoothTime = 0.3f; // Smoothing factor
    public Vector3 offset; // Offset from the player's position

    private Transform target; // The player's Transform

    private void Awake()
    {
        // Find the player GameObject by tag and get its Transform
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            target = player.transform;
        }
        else
        {
            Debug.LogWarning("No GameObject found with the 'Player' tag! Please assign the correct tag to the player.");
        }
    }

    private void LateUpdate()
    {
        // If the target is not set, do nothing
        if (target == null) return;

        // Calculate the target position based on the player's position and offset
        Vector3 targetPosition = target.position + offset;

        // Keep the z position fixed (e.g., -10 for 2D games)
        targetPosition.z = transform.position.z;

        // Smoothly move the camera to the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
