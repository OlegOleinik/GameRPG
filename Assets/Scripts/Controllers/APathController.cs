using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.SceneManagement;

public class APathController : MonoBehaviour
{
    private float waitTime = 0;
    private void Start()
    {
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    public void OnSceneUnloaded(Scene scene)
    {
        //Проверка, чтобы не обновлялось по 8 раз
        if (waitTime < Time.time)
        {
            UpdatePositions();
            waitTime = Time.time + 1f;
        }
    }
    public void UpdatePositions()
    {
        AstarPath astarPath = GetComponent<AstarPath>();
        (astarPath.graphs[0] as GridGraph).center = GameManager.player.transform.position;
        var graphToScan = AstarPath.active.data.gridGraph;
        astarPath.Scan(graphToScan);
    }
}
