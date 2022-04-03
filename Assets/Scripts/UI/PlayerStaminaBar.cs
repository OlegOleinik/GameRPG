using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStaminaBar : MonoBehaviour
{
    MaterialPropertyBlock matBlock;
    MeshRenderer meshRenderer;
    Camera mainCamera;
    private Player player;


    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        matBlock = new MaterialPropertyBlock();
        player = GameManager.player.GetComponent<Player>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        UpdateParams();

    }

    private void UpdateParams()
    {
        meshRenderer.GetPropertyBlock(matBlock);
        matBlock.SetFloat("_Fill", player.currentStamina / player.maxStamina);
        meshRenderer.SetPropertyBlock(matBlock);
    }

}
