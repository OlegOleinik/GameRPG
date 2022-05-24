using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;

public class Wall : MonoBehaviour
{
    public void UpdateShadows()
    {
        foreach (var item in GetComponentsInChildren<ShadowCaster2D>())
        {
            DestroyImmediate(item.gameObject);
        }

        CompositeCollider2D tilemapCollider = GetComponent<CompositeCollider2D>();
        for (int i = 0; i < tilemapCollider.pathCount; i++)
        {
            Vector2[] pathVertices = new Vector2[tilemapCollider.GetPathPointCount(i)];
            tilemapCollider.GetPath(i, pathVertices);
            GameObject shadowCaster = new GameObject("ShadowCaster" + i);
            PolygonCollider2D shadowPolygon = (PolygonCollider2D)shadowCaster.AddComponent(typeof(PolygonCollider2D));
            shadowCaster.transform.parent = gameObject.transform;
            shadowCaster.transform.position = shadowCaster.transform.position + GetComponentInParent<Grid>().gameObject.transform.position;
            shadowPolygon.points = pathVertices;
            shadowCaster.AddComponent<ShadowCaster2D>();

            DestroyImmediate(shadowPolygon);

        }
    }
}
