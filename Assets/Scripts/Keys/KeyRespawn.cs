using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRespawn : MonoBehaviour
{
    public GameObject key;
    public Transform respawnPoint;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            RespawnKey();
            Destroy(gameObject);
        }
    }

    private void RespawnKey()
    {
        GameObject Key = Instantiate(key, respawnPoint.position, Quaternion.identity);
    }
}