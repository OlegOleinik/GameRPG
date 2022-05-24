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
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    }
    public void Interact(InputAction.CallbackContext inputValue)
    {
        if (inputValue.phase == InputActionPhase.Started && this.interaction != null)
        {
            interaction();
        }
<<<<<<< HEAD
     }
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream

     }


=======
     }
>>>>>>> Stashed changes
=======
     }
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
}