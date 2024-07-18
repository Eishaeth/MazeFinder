using System;
using UnityEngine;

public class CollectibleDescription : MonoBehaviour
{
    // public static event Action OnCollected;

    public float displayTime = 5f;

    private bool isDisplaying = false;

    TMPro.TMP_Text text;
    int count;

    void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
        isDisplaying = true;
    }

    void OnEnable() => Collectible.OnCollected += OnCollectibleCollected; 
    void OnDisable() => Collectible.OnCollected -= OnCollectibleCollected;

    void OnCollectibleCollected()
    {
        text.text = "The yellow door has been opened";
        
        Invoke("HideItemText", displayTime);
    }
    void HideItemText()
    {
        if (isDisplaying)
        {
            text.CrossFadeAlpha(0, 1, false);
            isDisplaying = false;
        }
    }
}