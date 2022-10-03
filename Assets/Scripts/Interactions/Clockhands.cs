using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clockhands : MonoBehaviour
{
    [SerializeField]
    private Clockhand secondHand;
    [SerializeField]
    private Clockhand minuteHand;
    [SerializeField]
    private Clockhand hourHand;


    private void Update()
    {
        if (secondHand.NumberPointing == GameManager.SecondWin &&
            minuteHand.NumberPointing == GameManager.MinuteWin &&
            hourHand.NumberPointing == GameManager.HourWin)
        {
            //play door open sound
            StartCoroutine(Win.ExitToCredits());
        }
    }
}
