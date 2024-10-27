using TMPro;
using UnityEngine;
using System.Collections;

public class TextShower : MonoBehaviour
{
    [TextArea(15,20)]
    [SerializeField] private string textToShow;
    [SerializeField] private TextMeshProUGUI textMeshPro;

    [SerializeField] private float characterInterval = 0.04f;

    [SerializeField] private float delay = 0f;

    // [SerializeField] private AudioClip sound;
    [SerializeField] private AudioSource source;

    // Setter for the text to show
    public string TextToShow
    {
        set
        {
            textToShow = value;
            ChangeText();
        }
    }

    private void ChangeText()
    {
        // Stop any existing coroutine before starting a new one
        StopAllCoroutines();
        StartCoroutine(UpdateTextCoroutine());
    }

    private IEnumerator UpdateTextCoroutine()
    {
        textMeshPro.text = "";

        yield return new WaitForSeconds(delay);
        
        source.Play();
        
        foreach (var c in textToShow.ToCharArray())
        {
            textMeshPro.text += c;
            // Wait for the word interval
            yield return new WaitForSeconds(characterInterval);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChangeText();
    }

    // Update is called once per frame
    void Update()
    {

    }
}