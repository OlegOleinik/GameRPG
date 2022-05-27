using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public abstract class AButton : MonoBehaviour
{
    public virtual void OnAction(InputAction.CallbackContext inputValue)
<<<<<<< Updated upstream
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    {
        
        if (inputValue.started)
        {

<<<<<<< HEAD
=======
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

>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
            OpenClosePanel();
        }
    }
    public virtual void OpenClosePanel()
    {
        GameManager.ClickPlay();
    }
<<<<<<< HEAD
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
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
