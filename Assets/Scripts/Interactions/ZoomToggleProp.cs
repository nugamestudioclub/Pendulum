using System.Collections;
using UnityEngine;

public class ZoomToggleProp : ToggleProp
{
    [SerializeField] private float maxTime = 1f;
    [SerializeField] private float distanceFromObject = 1f;
    private Vector3 _initpos;
    private Transform _transformCamera;


    private void Awake()
    {
        _transformCamera = Camera.main.transform;
        _initpos = _transformCamera.position;
    }
    
    IEnumerator ZoomIn()
    {
        // smooth move the object 1 units infront of the camera
        float time = 0f;

        Vector3 startPos = _transformCamera.position;

        var objecttransform = transform;
        Vector3 endPos = objecttransform.position + objecttransform.forward * distanceFromObject;
            while (time < maxTime)
            {
                time += Time.deltaTime;
                _transformCamera.position = Vector3.Lerp(startPos, endPos, time / maxTime);
                yield return null;
            }
    }

    IEnumerator ZoomOut()
    {
        // smooth move the object 1 units infront of the camera
        float time = 0f;

        Vector3 startPos = _transformCamera.position;
        Vector3 endPos = _initpos;
            while (time < maxTime)
            {
                time += Time.deltaTime;
                _transformCamera.position = Vector3.Lerp(startPos, endPos, time / maxTime);
                yield return null;
            }
    }

    protected override int NumStates => 2;

    protected override void EnterState(int stateNum)
    {
        if (stateNum == 1)
        {
            StartCoroutine(ZoomIn());
        }
        else if (stateNum == 0)
        {
            StartCoroutine(ZoomOut());
        }
    }
}