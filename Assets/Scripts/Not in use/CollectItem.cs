using System;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
   

    void Update()
    {
        transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);

            // Replace with either FindFirstObjectByType or FindAnyObjectByType
            GameController gameController = FindAnyObjectByType<GameController>(); // Or FindFirstObjectByType<GameController>()
            gameController.CollectItem();
        }
    }
}
