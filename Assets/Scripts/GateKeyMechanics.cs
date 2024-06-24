using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateKeyMechanics : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            Destroy(gameObject);
        }
    }

}
