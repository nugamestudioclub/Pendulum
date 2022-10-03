using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticking : MonoBehaviour
{
    [SerializeField]
    private AudioClip tickClip;
    [SerializeField]
    private AudioClip resetClip;
    private AudioSource source;

    [SerializeField]
    private Clockhand hourHand;
    [SerializeField]
    private Clockhand minuteHand;
    [SerializeField]
    private Clockhand hourHandInspect;
    [SerializeField]
    private Clockhand minuteHandInspect;
    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    private void Update()
    {
        //Debug.Log($"Source is playing? {source.isPlaying}");
        if (!source.isPlaying) {
            float currentTime = GameManager.TimeElapsed;
            if (Mathf.Abs(currentTime - GameManager.TickLength) < 0.1f)
            {
                hourHand.Tick();
                hourHandInspect.Tick();
                source.PlayOneShot(resetClip);
            }
            else if (Mathf.Abs(currentTime - (int)currentTime) < 0.1f)
            {
                minuteHand.Tick();
                minuteHandInspect.Tick();
                source.PlayOneShot(tickClip);
            }
            //Debug.Log($"Current time: {currentTime}, {(int)currentTime}");
        }
    }
}
