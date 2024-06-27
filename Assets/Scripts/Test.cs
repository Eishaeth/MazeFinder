using UnityEngine;
using UnityEngine.XR;

public class XRDeviceDetection : MonoBehaviour
{
    public GameObject objectToDestroy;
    public GameObject doorToOpen;



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // Assuming your XR rig is tagged as "XRPlayer"
        {
            Destroy(objectToDestroy);

            if (doorToOpen != null)
            {
                doorToOpen.SetActive(false); // Set the door to be open
            }
        }
    }
}