using UnityEngine;
using UnityEngine.SceneManagement;

public class TravelManager : MonoBehaviour
{
    // Call this from your button and type in the TRANSITION scene name
    public void TravelToPlanet(string transitionSceneName)
    {
        // Instantly blasts the player to the Transition Scene!
        SceneManager.LoadScene(transitionSceneName);
    }
}