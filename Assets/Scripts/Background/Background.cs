using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private Vector2 offsetMod;
    [SerializeField] private bool isMoving = false;
    [SerializeField] private Vector2 moveSpeed;

    private Transform cameraT;
    private float tpOffset;
    private float timeCounter = 0;
    private float startPosY;
    private void Start()
    {
        cameraT = GetComponentInParent<Camera>().gameObject.transform;
        tpOffset = (GetComponent<SpriteRenderer>().size.x / 3) * transform.localScale.x;
        startPosY = transform.localPosition.y;
    }

    private void FixedUpdate()
    {
        Vector2 pos = cameraT.position * offsetMod;
        transform.position = pos;

        if (isMoving)
        {
            transform.position += (Vector3)moveSpeed * timeCounter;
            timeCounter += 0.1f;
        }


        float count = transform.localPosition.x / tpOffset;
        if (Mathf.Abs(count) > 1)
        {
            if (count > 0)
            {
                count = Mathf.Floor(count);
            }
            else
            {
                count = Mathf.Ceil(count);
            }
            timeCounter = 0;
            transform.localPosition = new Vector2(transform.localPosition.x - (count * tpOffset), transform.localPosition.y + startPosY);
            return;
        }
        transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + startPosY);
    }

}
