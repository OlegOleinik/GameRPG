using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class OpenPanelButton : MonoBehaviour
{

    [SerializeField] private APanel panel;
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
        UIScript uIScript = GetComponentInParent<UIScript>();
        if (uIScript.CheckNotOpen(panel.gameObject))
        {
            panel.gameObject.SetActive(true);
            panel.OpenPanel();
            uIScript.ExpandPanel(panel.gameObject, transform.localPosition);
        }
    }
}
