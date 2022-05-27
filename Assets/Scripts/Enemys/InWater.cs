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
<<<<<<< HEAD

=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
=======

>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======

>>>>>>> Stashed changes
    private void OnTriggerEnter2D(Collider2D collision)
    {
        sprite.sortingOrder = 1;
    }
<<<<<<< Updated upstream
<<<<<<< HEAD

=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
=======

>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======

>>>>>>> Stashed changes
    private void OnTriggerExit2D(Collider2D collision)
    {
        sprite.sortingOrder = defSort;
    }
<<<<<<< Updated upstream
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
>>>>>>> Stashed changes
}

