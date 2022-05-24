using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletRicochetSpell : ASpell
{
    [SerializeField] private GameObject bullet;
    private float lvlMod;
    private float time;
    private LineRenderer line;
    private Transform castPoint;
    public override void Start()
    {
        transform.position = GameManager.player.transform.position;
        base.Start();
    }

    public override bool Spell()
    {
        GameObject newBullet = Instantiate(bullet);
        newBullet.GetComponent<BulletRicochetBullet>().Shoot(lvlMod, time, castPoint);
        return true;
    }

    public override void SetLvl(int lvl)
    {
        castPoint = GameManager.player.GetComponent<Player>().spellCastPoint;
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
            line.SetPosition(0, castPoint.position);
            float x = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).x - castPoint.position.x;
            float y = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).y - castPoint.position.y;
            Vector3 dir = new Vector3(x, y, -1).normalized;
            RaycastHit2D hit = Physics2D.Raycast(castPoint.position, dir, 15f, layerMask);
            if (hit.collider!=null)
            {
                line.SetPosition(1, new Vector3(hit.point.x, hit.point.y, -1));
            }
            else
            {
                line.SetPosition(1, castPoint.position + (15 * dir));
            }
            yield return null;
        }
    }
}
