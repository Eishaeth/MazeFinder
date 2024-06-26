using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public static event Action OnCollected;

    public GameObject door;

    
    void Update()
    {
        transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollected?.Invoke();
            Destroy(gameObject);
            OpenWall();
        }
    }

    void OpenWall()
    {

        {
            door.SetActive(false);
        }
    }
}