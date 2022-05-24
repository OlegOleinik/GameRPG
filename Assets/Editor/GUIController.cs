using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GUIController : Editor
{



}
[CustomEditor(typeof(TileRandom))]
public class RandomTiles : Editor
{
    override public void OnInspectorGUI()
    {
        TileRandom tileRandom = (TileRandom)target;
        if (GUILayout.Button("Random"))
        {
            tileRandom.RandomizeTiles();
        }
        DrawDefaultInspector();
    }
}

[CustomEditor(typeof(Wall))]
public class WallShadow : Editor
{
    override public void OnInspectorGUI()
    {
        Wall wall = (Wall)target;
        if (GUILayout.Button("Update Shadows"))
        {
            wall.UpdateShadows();
        }
        DrawDefaultInspector();
    }
}

[CustomEditor(typeof(APathController))]
public class PathController : Editor
{
    override public void OnInspectorGUI()
    {
        APathController aPathController = (APathController)target;
        if (GUILayout.Button("Update position"))
        {
            aPathController.UpdatePositions();
        }
        DrawDefaultInspector();
    }
}
