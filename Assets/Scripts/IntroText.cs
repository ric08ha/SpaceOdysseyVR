using System.Collections;
using UnityEngine;
using TMPro;

public class IntroText : MonoBehaviour
{
    public TextMeshProUGUI introText;
    public float typeSpeed = 0.05f; // How fast each letter appears

    void Start()
    {
        // Start with empty text
        introText.text = "";
        // Begin the animation
        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        // Loop through each letter in your message
        foreach (char letter in "SPACE ODYSSEY".ToCharArray())
        {
            introText.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }
}