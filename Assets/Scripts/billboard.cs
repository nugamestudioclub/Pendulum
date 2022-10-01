using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billboard : MonoBehaviour
{
    void Update()
    {
    }

    private void OnGUI()
    {
        transform.LookAt(Camera.main.transform);

    }
}
