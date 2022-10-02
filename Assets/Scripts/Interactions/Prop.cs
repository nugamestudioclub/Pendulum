using UnityEngine;

public abstract class Prop : MonoBehaviour
{
    [SerializeField] private GameObject menuHandler;
    protected abstract void Activate();
    private void OnMouseDown()
    {
        Debug.Log($"{name} was clicked");
        if(menuHandler.GetComponent<InGameMenu>().gameisPaused == false)
        {
            Activate();
        }
    }
   
}
