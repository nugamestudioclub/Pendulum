using System;
using System.Collections;
using UnityEngine;

public class Win : MonoBehaviour
{
    public static IEnumerator ExitToCredits()
    {
        yield return new WaitForSeconds(2);  
        Initiate.Fade("Credits",Color.black,2f);
        yield return null;
    }
}
