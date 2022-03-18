using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpell : ASpell
{
    [SerializeField] GameObject wall;
    public override void Start()
    {
        //gameObject.SetActive(true);
        //transform.position = (Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition));

    }
    private void Update()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - GameManager.player.transform.position.x;
        float angle = Mathf.Atan2(Camera.main.ScreenToWorldPoint(Input.mousePosition).y - GameManager.player.transform.position.y, x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    public override void Spell()
    {
        GameObject newWall = Instantiate(wall);
        newWall.transform.position = transform.position;
        newWall.transform.rotation = transform.rotation;
       // newWall
    }
}
