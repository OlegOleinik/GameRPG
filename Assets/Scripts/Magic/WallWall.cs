using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class WallWall : MonoBehaviour
{
    private float lifeTime;
    public void WallSet(float lifeTime, float wallHeight)
    {
        this.lifeTime = Time.time + lifeTime;
        GetComponent<SpriteRenderer>().size = new Vector2(0.5f, wallHeight);
        GetComponent<BoxCollider2D>().size = new Vector2(0.5f, wallHeight);
        Vector3[] shapes = gameObject.GetComponent<ShadowCaster2D>().shapePath;
        shapes[0] = new Vector3(0.02f, wallHeight/2);
        shapes[1] = new Vector3(0.02f, -wallHeight / 2);
        shapes[2] = new Vector3(-0.25f, -wallHeight / 2);
        shapes[3] = new Vector3(-0.25f, wallHeight / 2);
    }

    private void Update()
    {
        if (lifeTime < Time.time)
        {
            Destroy(gameObject);
        }
    }
}
