using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryBallRespawn : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform respawnPoint;

    void OnCollisionEnter(Collision collision)
    {
         if (collision.gameObject.CompareTag("Ball"))
        {
            RespawnBall();
            Destroy(gameObject);
        }
    }

    private void RespawnBall()
    {
        GameObject Ball = Instantiate(ballPrefab, respawnPoint.position, Quaternion.identity);
    }
}