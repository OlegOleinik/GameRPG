using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< Updated upstream
=======
<<<<<<<< Updated upstream:Assets/Scripts/UI/Bars/ABar.cs
>>>>>>> Stashed changes
public abstract class ABar : MonoBehaviour
{
    public MaterialPropertyBlock matBlock;
    public MeshRenderer meshRenderer;
    public Camera mainCamera;
<<<<<<< Updated upstream
    //private Player player;

=======
>>>>>>> Stashed changes

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        matBlock = new MaterialPropertyBlock();
<<<<<<< Updated upstream
        //player = GameManager.player.GetComponent<Player>();
=======
>>>>>>> Stashed changes
        mainCamera = Camera.main;
        SetLocalParams();
    }

    public virtual void Update()
    {
        UpdateParams();
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
    }

    public void UpdateParams()
    {
        meshRenderer.GetPropertyBlock(matBlock);
        matBlock.SetFloat("_Fill", UpdateCount());
        meshRenderer.SetPropertyBlock(matBlock);
    }

    public abstract float UpdateCount();
    public abstract void SetLocalParams();
<<<<<<< Updated upstream
=======
========
public class PlayerStaminaBar : ABar
{
    private Player player;

    public override float UpdateCount()
    {
        return player.currentStamina / player.maxStamina;
    }
    public override void SetLocalParams()
    {
        player = GameManager.player.GetComponent<Player>();
    }
>>>>>>>> Stashed changes:Assets/Scripts/UI/PlayerStaminaBar.cs
>>>>>>> Stashed changes
}
