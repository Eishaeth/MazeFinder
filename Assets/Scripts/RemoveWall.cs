using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveWall : MonoBehaviour
{
    public GameObject door;

    private bool isDoorOpen = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isDoorOpen)
        {
            OpenDoor();
            isDoorOpen = true;
        }
    }

    void OpenDoor()
    {
        if (door != null)
        {
            // You can add animations, sound effects, or other actions to open the door here
            door.SetActive(false); // Example: Deactivate the door game object
        }
    }
}
