using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public abstract class AButton : MonoBehaviour
{
    public virtual void OnAction(InputAction.CallbackContext inputValue)
    {
        
        if (inputValue.started)
        {

            OpenClosePanel();
        }
    }
    public virtual void OpenClosePanel()
    {
        GameManager.ClickPlay();
    }
}
