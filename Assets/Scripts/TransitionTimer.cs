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
        // 1. Convert the input to lowercase and check if it's the spacecraft
        if (finalPlanetScene == "Spacecraft")
        {
            Debug.Log("Destination is spacecraft. Halting transition timer.");
            // 2. The 'return' stops the Start method right here, 
            // so the countdown coroutine never even begins!
            return;
        }

        // 3. If it's a planet, proceed with the normal countdown
        StartCoroutine(WaitAndLoad());
    }

    private IEnumerator WaitAndLoad()
    {
        // Wait for your set time (5 seconds)
        yield return new WaitForSeconds(waitTime);

        // Load the final terrain scene!
        SceneManager.LoadScene(finalPlanetScene);
    }
}