using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public abstract class AButton : MonoBehaviour
{
    public virtual void OnAction(InputAction.CallbackContext inputValue)
<<<<<<< Updated upstream
    {
        
        if (inputValue.started)
        {

<<<<<<< Updated upstream
    // [SerializeField] private string buttonName;
    //public void CheckKeyboardPress()
    //{
    //    if (Input.GetButtonDown(buttonName))
    //    {
    //        OpenClosePanel();
    //    }

    //}
    public abstract void OnAction(InputAction.CallbackContext inputValue);
    public abstract void OpenClosePanel();
    // Start is called before the first frame update


=======
            OpenClosePanel();
        }
    }
    public virtual void OpenClosePanel()
    {
        GameManager.ClickPlay();
    }
>>>>>>> Stashed changes
=======
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
>>>>>>> Stashed changes
}
