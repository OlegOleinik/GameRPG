using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class LaserRicochetSpell : ASpell
{
    private int maxRicochetCount;
    private float lvlMod;
    private LayerMask layerMask;
    private Transform castPoint;
    private LineRenderer laserLineRenderer;
    private int ricochetCount = 0;
    private float laserMaxLength = 10f;
    [SerializeField] private GameObject laserBeam;
    [SerializeField] private LineRenderer aimLine;

    public override bool Spell()
    {
        GameObject newLaserBeam = Instantiate(laserBeam, GameManager.player.transform);
        newLaserBeam.GetComponent<LaserBeam>().CastLaser(maxRicochetCount, lvlMod, castPoint);
        return true;
    }
    private void StartAIM()
    {
        layerMask = LayerMask.GetMask("Wall");
        StartCoroutine(ShootLine());
        aimLine.enabled = true;
    }

    public override void SetLvl(int lvl)
    {
        castPoint = GameManager.player.GetComponent<Player>().spellCastPoint;
        switch (lvl)
        {
            case 1:
                lvlMod = 1;
                maxRicochetCount = 1;
                aimLine.enabled = false;
                break;
            case 2:
                lvlMod = 1.2f;
                maxRicochetCount = 2;
                aimLine.enabled = false;
                break;
            case 3:
                lvlMod = 1.5f;
                maxRicochetCount = 3;
                aimLine.enabled = false;
                break;
            case 4:
                lvlMod = 1.6f;
                maxRicochetCount = 4;
                StartAIM();
                break;
            case 5:
                lvlMod = 2;
                maxRicochetCount = 4;
                StartAIM();
                break;
            default:
                break;
        }
    }

    void ShootLaser(Vector2 targetPosition, Vector2 direction, float length)
    {
        RaycastHit2D hit = Physics2D.Raycast(targetPosition, direction, length, layerMask);
        Debug.DrawRay(targetPosition, direction * length, Color.black, 10);
        Vector2 endPosition = targetPosition + (length * direction);
        bool isRicochet = false;
        Vector2 newDir = new Vector2(0, 0);
        if (hit.collider != null && hit.collider.tag == "Wall")
        {
            if (ricochetCount < maxRicochetCount)
            {
                isRicochet = true;
                ricochetCount++;
                newDir = Vector2.Reflect(direction, hit.normal);
                endPosition = hit.point + (newDir.normalized / 100);
            }
            else
            {
                endPosition = hit.point;
            }
        }
        aimLine.SetPosition(++aimLine.positionCount - 1, endPosition);
        if (isRicochet)
        {
            ShootLaser(endPosition, newDir, length);
        }
    }

    private IEnumerator ShootLine()
    {
        while (true)
        {
            ricochetCount = 0;
            aimLine.positionCount = 1;
            float x = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).x - castPoint.position.x;
            float y = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).y - castPoint.position.y;
            aimLine.SetPosition(0, castPoint.position);
            ShootLaser(castPoint.position, new Vector2(x, y).normalized, laserMaxLength);
            yield return null;
        }
    }
}

