using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LaserBeam : MonoBehaviour
{
    private LayerMask layerMask;
    [SerializeField] private LineRenderer line;
    private int ricochetCount = 0;
    private float laserMaxLength = 10f;
    private int maxRicochetCount;
    private GameManager.EndCorutine end;
    private float lvlMod;
    public void CastLaser(int maxRicochetCount, float lvlMod, Transform castPoint)
    {
        this.lvlMod = lvlMod;
        this.maxRicochetCount = maxRicochetCount;
        line.positionCount = 1;
        line.startColor = new Color(0.64f, 0, 1f, 1f);
        line.endColor = new Color(0.64f, 0, 1f, 1f);
        ricochetCount = 0;
        end = SetNoActive;
        layerMask = LayerMask.GetMask("Wall") + LayerMask.GetMask("Enemys") + LayerMask.GetMask("NonWaterEnemys");
        float x = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).x - castPoint.position.x;
        float y = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).y - castPoint.position.y;
        line.SetPosition(0, castPoint.position);
        ShootLaser(castPoint.position, new Vector2(x, y).normalized, laserMaxLength);
    }

    private void SetNoActive()
    {
        Destroy(gameObject);
    }

    void ShootLaser(Vector2 targetPosition, Vector2 direction, float length)
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(targetPosition, direction, length, layerMask);
        Debug.DrawRay(targetPosition, direction * length, Color.black, 10);
        Vector2 endPosition = targetPosition + (length * direction);
        bool isRicochet = false;
        Vector2 newDir = new Vector2(0, 0);
        foreach (var item in hit)
        {
            if (item.collider.tag != "Wall")
            {
                item.collider.GetComponent<IDamagable>()?.GetDamage((0.5f * GameManager.player.GetComponent<Player>().magicDamage) + (0.5f * lvlMod));
                if (item.collider.tag == "NPC")
                {
                    item.collider.GetComponent<ANPC>().GetAttackedByPlayer();
                }
            }
            else
            {
                if (ricochetCount < maxRicochetCount)
                {
                    isRicochet = true;
                    ricochetCount++;
                    newDir = Vector2.Reflect(direction, item.normal);
                    endPosition = item.point + (newDir.normalized / 100);
                }
                else
                {
                    endPosition = item.point;
                }
                break;
            }
        }
        line.SetPosition(++line.positionCount - 1, endPosition);
        if (isRicochet)
        {
            ShootLaser(endPosition, newDir, length);
        }
        else
        {
            StartCoroutine(1f.Tweeng((u) => line.startColor = new Color(1f, 1f, 1f, u), 1f, 0f));
            StartCoroutine(1f.Tweeng((u) => line.endColor = new Color(1f, 1f, 1f, u), 1f, 0f, end));
        }
    }
}
