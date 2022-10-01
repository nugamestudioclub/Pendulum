using UnityEngine;
// ReSharper disable CompareOfFloatsByEqualityOperator

public class Navigation : MonoBehaviour
{
    private bool _facingDown;
    private bool _facingUp;
    private bool _canSide = true;

    void Update()
    {
        //rotate the object depending on the keys pressed
        if(Input.anyKeyDown)
        {
            Turn();
        }

        
    }

    private void UpAndDownCheck()
    {
        if (transform.eulerAngles.x == 0)
        {
            _facingUp = false;
            _facingDown = false;
            _canSide = true;
            
        }
        if(transform.eulerAngles.x == 270)
        {
            _facingUp = true;
            _facingDown = false;
            _canSide = false;
        }
        if (transform.eulerAngles.x == 90)
        {
            _facingUp = false;
            _facingDown = true;
            _canSide = false;
        }
    }

    private void Turn()
    {
        if (Input.GetKeyDown(KeyCode.A) && _canSide)
        {
            transform.Rotate(0, -90, 0);
        }

        if (Input.GetKeyDown(KeyCode.D) && _canSide)
        {
            transform.Rotate(0, 90, 0);
        }

        if (Input.GetKeyDown(KeyCode.W) && _facingUp == false)
        {
            transform.Rotate(-90, 0, 0);
            UpAndDownCheck();

        }

        if (Input.GetKeyDown(KeyCode.S) && _facingDown == false)
        {
            transform.Rotate(90, 0, 0);
            UpAndDownCheck();
        }
    }
}