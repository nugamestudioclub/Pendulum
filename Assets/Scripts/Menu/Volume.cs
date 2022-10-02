using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField] private Slider mainSlider;

    public void Awake()
    {
        //Adds a listener to the main slider and invokes a method when the value changes.
        mainSlider.onValueChanged.AddListener(delegate { VolumeChange(); });
        if (PlayerPrefs.GetFloat("volume") == 0)
        {
            PlayerPrefs.SetFloat("volume", 0.5f);
        }
        else
        {
            var volume = PlayerPrefs.GetFloat("volume");
            mainSlider.value = volume;
            AudioListener.volume = volume;
        }
    }

    // Invoked when the value of the slider changes.
    public void VolumeChange()
    {
        AudioListener.volume = mainSlider.value;
        PlayerPrefs.SetFloat("volume", mainSlider.value);
    }
}