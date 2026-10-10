using UnityEngine;

public class ChaseCamera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Transform player;
    Vector3 Velocity = Vector3.zero;
    private float smoothTime = 0.1f;
    private Vector3 offset = new Vector3(0,2f,1f);
    void Start()
    {
      
    }
    void LateUpdate()
    {
        if (player == null) return;
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + offset, ref Velocity, smoothTime); ;
    }
}
