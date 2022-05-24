using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InWater : MonoBehaviour
{
    private SpriteRenderer sprite;
    private int defSort;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        defSort = sprite.sortingOrder;
    }
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
    private void OnTriggerEnter2D(Collider2D collision)
    {
        sprite.sortingOrder = 1;
    }
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
    private void OnTriggerExit2D(Collider2D collision)
    {
        sprite.sortingOrder = defSort;
    }
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
}

