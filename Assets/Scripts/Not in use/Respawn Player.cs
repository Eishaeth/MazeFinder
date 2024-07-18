using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    public Transform respawnPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        // Move the player to the respawn point
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = respawnPoint.position;
        player.transform.rotation = respawnPoint.rotation;
    }
}