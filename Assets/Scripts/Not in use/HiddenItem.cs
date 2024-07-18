using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenItem : MonoBehaviour
{
    public GameObject itemToSpawn;
    public int targetsToHit = 3;
    private int targetsHit = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            targetsHit++;

            if (targetsHit >= targetsToHit)
            {
                Instantiate(itemToSpawn, transform.position, Quaternion.identity);
                targetsHit = 0; // Reset the targets hit
            }
        }
    }
}