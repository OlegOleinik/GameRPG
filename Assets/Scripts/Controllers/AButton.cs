using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AButton : MonoBehaviour
{

   // [SerializeField] private string buttonName;
    private void Update()
    {
        //CheckKeyboardPress();
    }
    //public void CheckKeyboardPress()
    //{
    //    if (Input.GetButtonDown(buttonName))
    //    {
    //        OpenClosePanel();
    //    }

    //}
    public abstract void OpenClosePanel();
    // Start is called before the first frame update


}
