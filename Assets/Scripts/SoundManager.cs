using UnityEngine;
using UnityEngine.UI;

public class AudioToggleButton : MonoBehaviour
{
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;
    public Image buttonImage;
    public bool isMuted = false;

    private void Start()
    {
        UpdateIcon();
    }

    public void ToggleAudio()
    {
        isMuted = !isMuted;

        // Toggle Audio
        AudioListener.volume = isMuted ? 0f : 1f;

        // Update Button Icon
        UpdateIcon();
    }

    private void UpdateIcon()
    {
        if (buttonImage == null)
        {
            //Debug.LogWarning("Button Image is not assigned!");
            return;
        }

        buttonImage.sprite = isMuted ? soundOffSprite : soundOnSprite;
    }
}
