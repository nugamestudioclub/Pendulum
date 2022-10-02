using System.Collections;
using UnityEngine;

// ReSharper disable CompareOfFloatsByEqualityOperator

public class Navigation : MonoBehaviour
{
    [SerializeField] private float rotationseconds = 0.5f;
    private bool _isRotating;
    void Update()
    {
        //rotate the object depending on the keys pressed
        if (Input.anyKeyDown)
        {
            Turn();
        }
    }
    private void Turn()
    {
        if (Input.GetKeyDown(KeyCode.A) && !_isRotating)
        {
            var eulerAngles = transform.eulerAngles;
            Quaternion desiredRotQ = Quaternion.Euler(eulerAngles.x, eulerAngles.y - 90, eulerAngles.z);
            StartCoroutine(SmoothRotate(desiredRotQ));
        }

        if (Input.GetKeyDown(KeyCode.D) && !_isRotating)
        {
            var eulerAngles = transform.eulerAngles;
            Quaternion desiredRotQ = Quaternion.Euler(eulerAngles.x, eulerAngles.y + 90, eulerAngles.z);
            StartCoroutine(SmoothRotate(desiredRotQ));
        }
    }

    IEnumerator SmoothRotate(Quaternion desiredRotQ)
    { 
        
        if (!_isRotating)
        {
            _isRotating = true;
            float currentRotatonSecs = 0;
            while (currentRotatonSecs < rotationseconds)
            {
                currentRotatonSecs += Time.deltaTime;
                transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Mathf.Clamp(currentRotatonSecs / rotationseconds,0f,1f));
                yield return null;
            }
            _isRotating = false;
        }
        
    }
}