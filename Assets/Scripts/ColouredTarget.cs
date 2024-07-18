using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class ColouredTarget : MonoBehaviour
{
    public GameObject door;

    //public GameObject ball;

    public Color hitColor = Color.red;

    private Renderer targetRenderer;

    private Color originalColor;

    void Start()
    {
        targetRenderer = GetComponent<Renderer>();
        originalColor = targetRenderer.material.color;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            ChangeColor(hitColor);
            OpenDoor();
            //Destroy(gameObject);
        }
    }

    private void ChangeColor(Color color)
    {
        targetRenderer.material.color = color;
    }

    private void ResetColor()
    {
        targetRenderer.material.color = originalColor;
    }
    private void OpenDoor()
    {
        door.SetActive(false);
    }
}
