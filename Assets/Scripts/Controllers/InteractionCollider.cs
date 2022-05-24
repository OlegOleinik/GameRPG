using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionCollider : MonoBehaviour
{
    private ANPC aNPC;

    private void Start()
    {
        aNPC = GetComponentInParent<ANPC>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        aNPC.OnInteractionTriggerStay2D(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        aNPC.OnInteractionTriggerExit2D(collision);
    }
}
