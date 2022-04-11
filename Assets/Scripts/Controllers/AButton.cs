using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public abstract class AButton : MonoBehaviour
{

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


}
