using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightSpell : ASpell
{
    [SerializeField] private GameObject lightPoint;
    private float lightRadius;
    private float lifeTime;
    public override void SetLvl(int lvl)
    {
        lightRadius = lvl;
        lifeTime = lvl * 60;
    }

    public override bool Spell()
    {
        foreach (var item in GameManager.player.GetComponentsInChildren<Light2D>())
        {
            if (item.gameObject.name == "LightArea")
            {
                item.gameObject.GetComponent<LightPoint>().LightSet(lifeTime, lightRadius);
                return true;
            }
        }
        GameObject newLight = Instantiate(lightPoint, GameManager.player.transform);
        newLight.name = "LightArea";
        newLight.GetComponent<LightPoint>().LightSet(lifeTime, lightRadius);
        return true;
    }
}
