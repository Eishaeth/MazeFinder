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
            //DisplayMessage("Yellow Door opened");
            OpenWall();
        }
    }

    /*void DisplayMessage(string message)
    {
        // Implement UI element to display the message
        Debug.Log(message);
    }*/

    void OpenWall()
    {

        {
            door.SetActive(false);
        }
    }
}
