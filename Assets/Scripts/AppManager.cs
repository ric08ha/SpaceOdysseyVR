using UnityEngine;

public class AppManager : MonoBehaviour
{
    // Call this from your Exit button
    public void QuitGame()
    {
        Debug.Log("Exiting the game...");

        // This quits the game when you are playing the final built app on your headset
        Application.Quit();

        // This cleverly stops the play mode while you are testing inside the Unity Editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}