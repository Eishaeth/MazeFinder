using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTimer : MonoBehaviour
{
    public string ToloadScene;
    private float timer = 8f;
    private bool timestart = false;

 void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("SceneChangeTimer");
        timestart = true;
        }
  //      else
  //      {
   //         timestart = false;
   //     }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timestart == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                SceneManager.LoadScene(ToloadScene);
            }
        }
    }

    
}
