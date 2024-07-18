using UnityEngine;

public class QuitButtonScript : MonoBehaviour
{
    public void QuitGame()
    {
        // If running build
#if UNITY_STANDALONE
            Application.Quit();
#endif

        // If running editor
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

