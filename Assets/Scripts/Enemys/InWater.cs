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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sprite.sortingOrder = 1;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        sprite.sortingOrder = defSort;
    }
}

