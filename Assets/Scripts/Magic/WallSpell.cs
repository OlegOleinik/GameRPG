using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WallSpell : ASpell
{
    [SerializeField] GameObject wall;
    private float wallHeight;
    private float maxDistance;
    public override void Start()
    {
        //gameObject.SetActive(true);
        //transform.position = (Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition));

    }
    private void Update()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        float x = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).x - GameManager.player.transform.position.x;
        float angle = Mathf.Atan2(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).y - GameManager.player.transform.position.y, x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    public override void Spell()
    {
        GameObject newWall = Instantiate(wall);
        newWall.transform.position = transform.position;
        newWall.transform.rotation = transform.rotation;
       // newWall
    }

    public override void SetLvl(int lvl)
    {
        switch (lvl)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                wallHeight = 2;
                break;
            default:
                break;
        }
    }
}
