using System;
using UnityEngine;

public class KeyRespawn2 : MonoBehaviour
{
    public Transform respawnPoint;
    public float minYValue = -5f; // Minimum Y value for respawning the ball
    public float maxYValue = 5f; // Maximum Y value for respawning the ball


    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        float currentY = transform.position.y;


        if (currentY < minYValue || currentY > maxYValue)
        {
            RespawnKeyAtPoint();
        }
    }

    void RespawnKeyAtPoint()
    {
        transform.position = respawnPoint.position;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}