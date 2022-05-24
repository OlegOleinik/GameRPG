using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TileRandom : MonoBehaviour
{
    [SerializeField] private TileBase[] newTiles;
    [SerializeField] private TileBase replacementTile;
    [SerializeField] private Tilemap tilemap;

    private void Awake()
    {
        newTiles = new TileBase[] { };
    }

    public void RandomizeTiles()
    {
        foreach (var position in tilemap.cellBounds.allPositionsWithin)
        {
            if (tilemap.HasTile(position) && (tilemap.GetTile(position) == replacementTile))
            {
                tilemap.SetTile(position, newTiles[Random.Range(0, (newTiles.Length - 1))]);
            }
        }
    }
}


