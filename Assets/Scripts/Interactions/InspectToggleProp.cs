using System.Collections;
using UnityEngine;

public class InspectToggleProp : ToggleProp
{
    [SerializeField] private float maxTime = 1f;
    [SerializeField] private float distanceFromCamera = 1f;
    private Vector3 _initpos;

    private void Awake()
    {
        _initpos = transform.position;
    }
    
    IEnumerator InspectObject()
    {
        // smooth move the object 1 units infront of the camera
        float time = 0f;

        Vector3 startPos = transform.position;
        if (Camera.main != null)
        {
            var transformCamera = Camera.main.transform;
            Vector3 endPos = transformCamera.position + transformCamera.forward * distanceFromCamera;
            while (time < maxTime)
            {
                time += Time.deltaTime;
                transform.position = Vector3.Lerp(startPos, endPos, time / maxTime);
                yield return null;
            }
        }
    }

    IEnumerator PlaceBackObject()
    {
        float time = 0f;

        Vector3 startPos = transform.position;
        if (Camera.main != null)
        {
            Vector3 endPos = _initpos;
            while (time < maxTime)
            {
                time += Time.deltaTime;
                transform.position = Vector3.Lerp(startPos, endPos, time / maxTime);
                yield return null;
            }
        }
    }

    protected override int NumStates => 2;

    protected override void EnterState(int stateNum)
    {
        if (stateNum == 1)
        {
            StartCoroutine(InspectObject());
        }
        else if (stateNum == 0)
        {
            StartCoroutine(PlaceBackObject());
        }
    }
}