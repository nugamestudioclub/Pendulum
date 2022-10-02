using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
  [SerializeField] private Slider mainSlider;

  public void Start()
  {
    //Adds a listener to the main slider and invokes a method when the value changes.
    mainSlider.onValueChanged.AddListener(delegate {VolumeChange(); });
    mainSlider.value = 0.5f;
    AudioListener.volume = 0.5f;
  }

  // Invoked when the value of the slider changes.
  public void VolumeChange()
  {
    AudioListener.volume = mainSlider.value;
  }
  
}
