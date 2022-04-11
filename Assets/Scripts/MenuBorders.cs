using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBorders : MonoBehaviour
{
    [SerializeField] float newX;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Transform tr = collision.gameObject.transform;
        tr.position = new Vector2(newX, tr.position.y);
    }
}
