using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TravelManager : MonoBehaviour
{
    [Header("UI Elements")]
    public Image fadePanel;
    public TextMeshProUGUI travelText;

    // Call this from your button's XR Simple Interactable
    public void TravelToPlanet(string sceneName)
    {
        StartCoroutine(TravelRoutine(sceneName));
    }

    private IEnumerator TravelRoutine(string sceneName)
    {
        // 1. Fade to black over 1 second
        float timer = 0f;
        Color c = fadePanel.color;

        while (timer < 1f)
        {
            timer += Time.deltaTime;
            c.a = Mathf.Clamp01(timer); // Increases alpha from 0 to 1
            fadePanel.color = c;
            yield return null;
        }

        // 2. Show text for 3 seconds
        // Cleans up "Planet_Moon" to just say "Approaching Moon..."
        string planetName = sceneName.Replace("Planet_", "");
        travelText.text = "Approaching " + planetName + "...";

        yield return new WaitForSeconds(3f);

        // 3. Load the scene
        SceneManager.LoadScene(sceneName);
    }
}