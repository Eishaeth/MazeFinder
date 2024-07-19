using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Level1GateKey : MonoBehaviour
{
    private int keysCollected = 0;

    private int keysRequired = 3;

    public GameObject gate;

    public Color hitColor = Color.red;

    public Color hitColour = Color.red;

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
            keysCollected++;
            Destroy(collision.gameObject);

            if (keysCollected == 1)
            {
                ChangeColor(hitColor);
            }

            if (keysCollected == 2)
            {
                ChangeColor(hitColour);
            }

            if (keysCollected >= keysRequired)
            {
                OpenGate();
            }
        }
    }
    private void ChangeColor(Color color)
    {
        targetRenderer.material.color = color;
    }
    void OpenGate()
    {

        {
            gate.SetActive(false);
        }
    }
}