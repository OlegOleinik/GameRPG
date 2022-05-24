using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WallSpell : ASpell
{
    [SerializeField] GameObject wall;
    [SerializeField] GameObject circle;
    private float wallHeight;
    private float maxDistance;
    private float lifeTime;
    private void Update()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        float x = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).x - GameManager.player.transform.position.x;
        float angle = Mathf.Atan2(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).y - GameManager.player.transform.position.y, x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    public override bool Spell()
    {
        if (Vector2.Distance(GameManager.player.transform.position, transform.position) < maxDistance)
        {
            GameObject newWall = Instantiate(wall, transform.position, transform.rotation);
            newWall.GetComponent<WallWall>().WallSet(lifeTime, wallHeight);
            return true;
        }
        return false;
    }

    public override void SetLvl(int lvl)
    {
        lifeTime = lvl;
        switch (lvl)
        {
            case 1:
                wallHeight = 1;
                maxDistance = 2.5f;

                break;
            case 2:
                wallHeight = 1.5f;
                maxDistance = 3;

                break;
            case 3:
                wallHeight = 2;
                maxDistance = 3.5f;
                break;
            case 4:
                wallHeight = 2.5f;
                maxDistance = 4;
               
                break;
            case 5:
                wallHeight = 3;
                maxDistance = 5;
                break;
            default:
                break;
        }
        circle = Instantiate(circle, GameManager.player.transform);
        circle.GetComponent<SpriteRenderer>().material.SetFloat("_Scale", 0.063f * maxDistance);
        GetComponent<SpriteRenderer>().size = new Vector2(0.5f, wallHeight);
    }

    private void OnDestroy()
    {
        Destroy(circle);
    }
}
