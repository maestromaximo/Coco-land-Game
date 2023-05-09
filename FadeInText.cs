using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeInText : MonoBehaviour
{
    // The UI text element that will be faded in
    public Text text;

    // The duration of the fade in effect
    public float duration = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Start the fade in coroutine
        StartCoroutine(FadeIn());
    }

    // Coroutine that fades in the text element
    IEnumerator FadeIn()
    {
        // Set the initial color of the text element to transparent
        text.color = new Color(1, 1, 1, 0);
        
        // Loop until the text element is fully visible
        while (text.color.a < 1.0f)
        {
            // Interpolate between the transparent color and the original color over time
            text.color = Color.Lerp(text.color, new Color(1, 0.65f, 0.04f, 1), Time.deltaTime / duration);

            // Wait for the next frame
            yield return null;
        }
    }
}
