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
<<<<<<< HEAD

=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
=======

>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    private void OnTriggerEnter2D(Collider2D collision)
    {
        sprite.sortingOrder = 1;
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
    private void OnTriggerExit2D(Collider2D collision)
    {
        sprite.sortingOrder = defSort;
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

