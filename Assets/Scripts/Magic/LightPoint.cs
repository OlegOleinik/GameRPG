using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightPoint : MonoBehaviour
{
    [SerializeField] private Light2D light2D;
    private float lifeTime;
    private float timer;
    private Color maxColor = new Color(0.57f, 0.94f, 1, 1);

    public void LightSet(float lifeTime, float lightRadius)
    {
        this.lifeTime = lifeTime;
        timer = Time.time + lifeTime;
        light2D.pointLightOuterRadius = lightRadius;
        light2D.color = maxColor;
    }

    private void Update()
    {
        light2D.color = new Color(0.57f, 0.94f, 1, (timer - Time.time)/lifeTime);
        if (timer < Time.time)
        {
            Destroy(gameObject);
        }
    }
}
