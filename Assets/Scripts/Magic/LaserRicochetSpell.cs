using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class LaserRicochetSpell : ASpell
{
    private LayerMask layerMask;
    private int ricochetCount = 0;
    private int maxRicochetCount;
    private float lvlMod;

    private LineRenderer laserLineRenderer;
    private float laserMaxLength = 10f;
    private GameManager.EndCorutine end;
    private LineRenderer line;
    [SerializeField] private GameObject aim;
    private GameObject newAim;
    //[SerializeField] private LineRenderer shootLine;
    public override void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        end = SetNoActive;
        gameObject.SetActive(false);
    }
    private void SetNoActive()
    {
        gameObject.SetActive(false);
    }
    public override void Spell()
    {
        gameObject.SetActive(true);
        line.positionCount = 1;
        line.startColor = new Color(0.64f, 0, 1f, 1f);
        line.endColor = new Color(0.64f, 0, 1f, 1f);
        ricochetCount = 0;

        layerMask = LayerMask.GetMask("Wall") + LayerMask.GetMask("Enemys");
        laserLineRenderer = gameObject.GetComponent<LineRenderer>();

        float x = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).x - GameManager.player.transform.position.x;
        float y = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).y - GameManager.player.transform.position.y;


        laserLineRenderer.SetPosition(0, GameManager.player.transform.position);
        ShootLaser(GameManager.player.transform.position, new Vector3(x, y, -1).normalized, laserMaxLength);
    }
    void ShootLaser(Vector3 targetPosition, Vector3 direction, float length)
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(targetPosition, direction, length, layerMask);
        Debug.DrawRay(targetPosition, direction*length, Color.black, 10);

        Vector3 endPosition = targetPosition + (length * direction);
        bool isRicochet = false;
        Vector2 newDir = new Vector2(0, 0);
        foreach (var item in hit)
        {
            if (item.collider.tag == "Enemy")
            {
                item.collider.GetComponent<AEnemy>().GetDamage((0.5f * GameManager.player.GetComponent<Player>().magicDamage) + (0.5f * lvlMod));
            }
            else if (item.collider.tag == "Wall")
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
        laserLineRenderer.SetPosition(++laserLineRenderer.positionCount - 1, endPosition);
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

    public override void SetLvl(int lvl)
    {
        switch (lvl)
        {
            case 1:
                lvlMod = 1;
                maxRicochetCount = 1;
                newAim = Instantiate(aim);
                newAim.GetComponent<LaserRicochetAim>().StartAim(maxRicochetCount);
                // shootLine.enabled = false;
                break;
            case 2:
                lvlMod = 1.2f;
                maxRicochetCount = 2;
                newAim = Instantiate(aim);
                newAim.GetComponent<LaserRicochetAim>().StartAim(maxRicochetCount);
                //  shootLine.enabled = false;
                break;
            case 3:
                lvlMod = 1.5f;
                maxRicochetCount = 3;
                newAim = Instantiate(aim);
                newAim.GetComponent<LaserRicochetAim>().StartAim(maxRicochetCount);
                // shootLine.enabled = false;
                break;
            case 4:
                lvlMod = 1.6f;
                maxRicochetCount = 4;
                newAim = Instantiate(aim);
                newAim.GetComponent<LaserRicochetAim>().StartAim(maxRicochetCount);
                // shootLine.enabled = true;
                //StartCoroutine(ShootLine());
                break;
            case 5:
                lvlMod = 2;
                maxRicochetCount = 4;
                newAim = Instantiate(aim);
                newAim.GetComponent<LaserRicochetAim>().StartAim(maxRicochetCount);
                // shootLine.enabled = true;
                //StartCoroutine(ShootLine());
                break;
            default:
                break;
        }
    }

    private void OnDestroy()
    {
        if (newAim!=null)
        {
            Destroy(newAim);
        }

    }


}

