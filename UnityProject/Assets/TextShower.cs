using TMPro;
using UnityEngine;
using System.Collections;

public class TextShower : MonoBehaviour
{
    [SerializeField] private string textToShow;
    [SerializeField] private TextMeshProUGUI textMeshPro;

    [SerializeField] private float characterInterval = 0.04f;

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