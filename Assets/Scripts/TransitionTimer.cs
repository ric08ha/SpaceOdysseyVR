using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionTimer : MonoBehaviour
{
    [Header("Destination Settings")]
    [Tooltip("Type the exact name of the final planet scene here (e.g., Saturn_Terrain)")]
    public string finalPlanetScene;

    [Tooltip("How many seconds to stay in this transition scene?")]
    public float waitTime = 5f;

    void Start()
    {
        // The moment this transition scene loads, start the countdown
        StartCoroutine(WaitAndLoad());
    }

    private IEnumerator WaitAndLoad()
    {
        // 1. Wait for your set time (5 seconds)
        yield return new WaitForSeconds(waitTime);

        // 2. Load the final terrain scene!
        SceneManager.LoadScene(finalPlanetScene);
    }
}