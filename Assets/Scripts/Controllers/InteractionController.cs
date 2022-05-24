using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionController : MonoBehaviour
{
    public delegate void Interaction();
    Interaction interaction;
    Vector2? interactionPos;
    public bool AddInteraction(Interaction interaction, Vector2 pos)
    {
        if (this.interaction != null)
        {
            if (this.interaction != interaction)
            {
                if (Vector2.Distance(transform.position, pos) < Vector2.Distance(transform.position, (Vector2)interactionPos))
                {
                    this.interaction = interaction;
                    interactionPos = pos;
                    return true;
                }
                return false;
            }
            else
            {
                interactionPos = pos;
                return true;
            }
        }
        else
        {
            this.interaction = interaction;
            interactionPos = pos;
            return true;
        }

    }
    public void ClearInteraction()
    {
        if (interaction != null)
        {
            interaction = null;
            interactionPos = null;
        }
    }

    public void RemoveInteraction(Interaction interaction)
    {
        if (this.interaction != null && this.interaction == interaction)
        {
            this.interaction = null;
            interactionPos = null;
        }
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
    }
    public void Interact(InputAction.CallbackContext inputValue)
    {
        if (inputValue.phase == InputActionPhase.Started && this.interaction != null)
        {
            interaction();
        }
<<<<<<< Updated upstream

     }


=======
     }
>>>>>>> Stashed changes
}
