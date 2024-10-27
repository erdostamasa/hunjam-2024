using UnityEngine;
using UnityEngine.UI;

public class UiSpriteChanger : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;

    private Image imageComponent;
    private float timer = 0f;
    private bool isSprite1Active = true;

    public float SwitchTime = 1f;
    void Start()
    {
        imageComponent = GetComponent<Image>();
        imageComponent.sprite = sprite1; // Set initial sprite
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= SwitchTime)
        {
            // Toggle the sprite
            isSprite1Active = !isSprite1Active;
            imageComponent.sprite = isSprite1Active ? sprite1 : sprite2;

            // Reset the timer
            timer = 0f;
        }
    }
}