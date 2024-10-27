using UnityEngine;
using System.Collections;

public class GameEndTrigger : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image fadingImage;
    [SerializeField] private float fadeDuration = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Start the coroutine to fade out and then switch to the next level
        StartCoroutine(FadeOutAndSwitchLevel());
    }

    private IEnumerator FadeOutAndSwitchLevel()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            var color = fadingImage.color;
            color.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadingImage.color = color;
            yield return null;
        }

        // Switch to the next level
        MenuManager.Instance.NextLevel();
    }
}