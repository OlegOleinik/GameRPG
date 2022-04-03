using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletRicochetSpell : ASpell
{
    // Start is called before the first frame update

    [SerializeField] private GameObject bullet;
    private float lvlMod;
    private float time;
    private LineRenderer line;
    public override void Start()
    {
        transform.position = GameManager.player.transform.position;
       
        
        transform.SetParent(GameManager.player.transform);
        
       
        //
    }

    public override void Spell()
    {
        GameObject newBullet = Instantiate(bullet);
        newBullet.GetComponent<BulletRicochetBullet>().Shoot(lvlMod, time);
    }

    public override void SetLvl(int lvl)
    {
        line = gameObject.GetComponent<LineRenderer>();
        switch (lvl)
        {
            case 1:
                lvlMod = 1;
                time = 3;
                line.enabled = false;
                break;
            case 2:
                lvlMod = 1.2f;
                time = 5;
                line.enabled = false;
                break;
            case 3:
                lvlMod = 1.5f;
                time = 7;
                line.enabled = false;
                break;
            case 4:
                lvlMod = 1.6f;
                time = 8;
                line.enabled = true;
                StartCoroutine(ShootLine());
                break;
            case 5:
                lvlMod = 2;
                time = 10;
                //line.enabled = true;
                line.enabled = true;
                StartCoroutine(ShootLine());
                break;
            default:
                break;
        }
    }

    private IEnumerator ShootLine()
    {

        LayerMask layerMask = LayerMask.GetMask("Wall");
        while (true)
        {

            line.SetPosition(0, GameManager.player.transform.position);
            float x = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).x - GameManager.player.transform.position.x;
            float y = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).y - GameManager.player.transform.position.y;
            Vector3 dir = new Vector3(x, y, -1).normalized;
            RaycastHit2D hit = Physics2D.Raycast(GameManager.player.transform.position, dir, 15f, layerMask);
            if (hit.collider!=null)
            {
                line.SetPosition(1, new Vector3(hit.point.x, hit.point.y, -1));
            }
            else
            {
                line.SetPosition(1, GameManager.player.transform.position + (15 * dir));
            }
            yield return null;
        }

    }
}
