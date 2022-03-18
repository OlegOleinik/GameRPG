using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
    MaterialPropertyBlock matBlock;
    MeshRenderer meshRenderer;
    Camera mainCamera;
    private Player player;

    //private void Awake()
    //{

    //    // get the damageable parent we're attached to
    //    //Enemy_1 = GetComponentInParent<Damageable>();
    //}

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        matBlock = new MaterialPropertyBlock();
        player = GameManager.player.GetComponent<Player>();
        // Cache since Camera.main is super slow
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // Only display on partial health
        //if (player.ex < enemy.maxHP)
        //{
        //print(enemy.currentHP);
        // meshRenderer.enabled = true;
        UpdateParams();
        //}
        //else
        //{
        //   // meshRenderer.enabled = false;
        //}
    }

    private void UpdateParams()
    {
        meshRenderer.GetPropertyBlock(matBlock);
        matBlock.SetFloat("_Fill", player.currentHP / player.maxHP);
        meshRenderer.SetPropertyBlock(matBlock);
    }

}
