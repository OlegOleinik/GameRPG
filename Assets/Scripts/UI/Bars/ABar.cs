using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ABar : MonoBehaviour
{
    public MaterialPropertyBlock matBlock;
    public MeshRenderer meshRenderer;
    public Camera mainCamera;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        matBlock = new MaterialPropertyBlock();
        mainCamera = Camera.main;
        SetLocalParams();
    }

    public virtual void Update()
    {
        UpdateParams();
    }

    public void UpdateParams()
    {
        meshRenderer.GetPropertyBlock(matBlock);
        matBlock.SetFloat("_Fill", UpdateCount());
        meshRenderer.SetPropertyBlock(matBlock);
    }

    public abstract float UpdateCount();
    public abstract void SetLocalParams();
}
