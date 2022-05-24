using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPSSpawner : MonoBehaviour
{
    [SerializeField] private ANPC[] aNPCs;
    List<ANPC> spawnedNPS = new List<ANPC>();
    private bool isAngry = false;
    [SerializeField] private GameObject saveArea;

    private void Start()
    {
        StartCoroutine(LastNPSSpawn());
    }

    private IEnumerator LastNPSSpawn()
    {
        yield return new WaitForEndOfFrame();
        SpawnNPSs();
    }

    public void SpawnNPSs()
    {
        NPCController nPCController = GameManager.player.GetComponent<NPCController>();
        foreach (var item in aNPCs)
        {
            if (!nPCController.nPCs[item.nPCid].isDead)
            {
                GameObject newNPC = Instantiate(item.gameObject, transform);
                spawnedNPS.Add(newNPC.GetComponent<ANPC>());
            }
        }
    }

    public void SetNPCsAngry()
    {
        if (!isAngry)
        {
            Destroy(saveArea);
            isAngry = true;
            foreach (var item in spawnedNPS)
            {
                if (item != null)
                {
                    item.SetAngryToPlayer();
                }
            }
        }
    }
}
