using UnityEngine;
 
public class MenuParallax : MonoBehaviour
{
    public float offsetMultiplier;
    public float smoothTime ;
 
    private Vector2 startPosition;
    private Vector3 velocity;
 
    private void Start()
    {
        startPosition = transform.position;
    }
 
    private void Update()
    {
        Vector2 offset = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        transform.position = Vector3.SmoothDamp(transform.position, startPosition + (offset * offsetMultiplier), ref velocity, smoothTime);
    }
}

