using System;
using UnityEngine;

public class Target : MonoBehaviour
{
   // public event Action OnTargetHit;

    public GameObject door;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            //OnTargetHit?.Invoke();
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        door.SetActive(false);
    }
}