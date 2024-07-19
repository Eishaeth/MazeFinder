using System;
using UnityEngine;

public class RespawnBall : MonoBehaviour
{
    public Transform respawnPoint;
    public float minYValue = -5f; // Minimum Y value for respawning the ball
    public float maxYValue = 5f; // Maximum Y value for respawning the ball
    public float minXValue = -5f; // Minimum X value for the restricted area
    public float maxXValue = 5f; // Maximum X value for the restricted area
    public float minZValue = -5f; // Minimum Z value for the restricted area
    public float maxZValue = 5f; // Maximum Z value for the restricted area


    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        float currentY = transform.position.y;
        float currentX = transform.position.x;
        float currentZ = transform.position.z;

        if (currentY < minYValue || currentY > maxYValue || currentX < minXValue || currentX > maxXValue || currentZ < minZValue || currentZ > maxZValue)
        {
            RespawnBallAtPoint();
        }
    }

    void RespawnBallAtPoint()
    {
        transform.position = respawnPoint.position;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}