using System;
using UnityEngine;

public class Target : MonoBehaviour
{
   // public event Action OnTargetHit;

    public GameObject door;

    public GameObject ball;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            //OnTargetHit?.Invoke();
            OpenDoor();
            Destroy(collision.gameObject);
        }
    }

    private void OpenDoor()
    {
        door.SetActive(false);
    }
}