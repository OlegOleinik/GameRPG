using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRicochetSpell : ASpell
{
    private LayerMask layerMask;
    private int ricochetCount = 0;
    private Vector2 lastHit;
    private Vector2 lastDir;


    private LineRenderer laserLineRenderer;
    private float laserMaxLength = 10f;
    private GameManager.EndCorutine end;
    public override void Start()
    {
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
        gameObject.GetComponent<LineRenderer>().positionCount = 1;
        gameObject.GetComponent<LineRenderer>().startColor = new Color(0.64f, 0, 1f, 1f);
        gameObject.GetComponent<LineRenderer>().endColor = new Color(0.64f, 0, 1f, 1f);
        ricochetCount = 0;

        layerMask = LayerMask.GetMask("Wall") + LayerMask.GetMask("Enemys");
        laserLineRenderer = gameObject.GetComponent<LineRenderer>();
        //Instantiate(gameObject);

        //Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        //laserLineRenderer.SetPositions(initLaserPositions);


        float x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - GameManager.player.transform.position.x;
        float y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - GameManager.player.transform.position.y;


        laserLineRenderer.SetPosition(0, GameManager.player.transform.position);
        ShootLaser(GameManager.player.transform.position, new Vector3(x, y, -1).normalized, laserMaxLength);
        // laserLineRenderer.SetWidth(laserWidth, laserWidth);
        // Instantiate(gameObject);
        //Debug.DrawRay(new Vector3(0, 0, 0), new Vector3(2, 2, 0), Color.blue, 20);



        ////laser = Instantiate(gameObject);
        //RaycastHit2D[] hit = Physics2D.RaycastAll(GameManager.player.transform.position, new Vector2(1, 1), 30, layerMask);
        //Debug.DrawRay(GameManager.player.transform.position, new Vector2(1, 1)*20, Color.black, 5);




        // Debug.Log(hit[0]);



        //gameObject.GetComponent<LineRenderer>().SetPosition(ricochetCount, GameManager.player.transform.position);
        //gameObject.GetComponent<LineRenderer>().positionCount++;
        //gameObject.GetComponent<LineRenderer>().SetPosition(ricochetCount, new Vector3(1,1,-1));
        //gameObject.GetComponent<LineRenderer>().SetPosition(0, new Vector3(GameManager.player.transform.position.x, GameManager.player.transform.position.y, -1));
        //CastLaser(GameManager.player.transform.position, new Vector2(x, y));
        // Debug.Log(Input.mousePosition.normalized);
        //RaycastHit2D hit = Physics2D.Raycast(GameManager.player.transform.position, new Vector2(x, y).normalized, 30, layerMask);




        // Debug.Log("Laser Pew Pew");
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
                item.collider.GetComponent<AEnemy>().GetDamage(1 * GameManager.player.GetComponent<Player>().magicDamage);
            }
            else if (item.collider.tag == "Wall")
            {
                if (ricochetCount < 4)
                {
                    isRicochet = true;
                    ricochetCount++;
                    //laserLineRenderer.positionCount++;
                    //ShootLaser(item.point, Vector2.Reflect(direction, item.normal), length, laserLineRenderer);
                    newDir = Vector2.Reflect(direction, item.normal);
                    endPosition = item.point;
                }
                break;
            }
        }
        //laserLineRenderer.positionCount++;
        laserLineRenderer.SetPosition(++laserLineRenderer.positionCount - 1, endPosition);
        if (isRicochet)
        {
            ShootLaser(endPosition, newDir, length);
        }
        //StartCoroutine(DisappearLaser());
        StartCoroutine(1f.Tweeng((u) => gameObject.GetComponent<LineRenderer>().startColor = new Color(0.64f, 0, 1f, u), 1f, 0f));
        StartCoroutine(1f.Tweeng((u) => gameObject.GetComponent<LineRenderer>().endColor= new Color(0.64f, 0, 1f, u), 1f, 0f, end));
    }



    //public void CastLaser(Vector2 origin, Vector2 dir)
    //{
    //    ricochetCount++;

    // RaycastHit2D


    //    Debug.DrawRay(origin, dir.normalized * 20, Color.blue, 7);
    //    //RaycastHit2D[] result;
    //    //RaycastHit2D hit = Physics2D.RaycastNonAlloc(GameManager.player.transform.position, new Vector2(x, y).normalized, result, 30, layerMask);
    //    RaycastHit2D[] hit = Physics2D.RaycastAll(origin, dir.normalized, 20, layerMask);
    //    bool stopLaser = true;

    //    foreach (var item in hit)
    //    {
    //        if (item.collider.tag == "Enemy")
    //        {
    //            item.collider.GetComponent<AEnemy>().GetDamage(1);
    //        }
    //        else if (item.collider.tag == "Wall" && ricochetCount < 4)
    //        {
    //            gameObject.GetComponent<LineRenderer>().positionCount++;
    //            gameObject.GetComponent<LineRenderer>().SetPosition(ricochetCount, new Vector3(item.point.x, item.point.y, -1));
    //            lastHit = item.normal;
    //            lastDir = dir;
    //            CastLaser(item.point, Vector2.Reflect(dir, item.normal));
    //            stopLaser = false;
    //            break;
    //        }
    //    }
    //    if (stopLaser)
    //    {
    //        if (ricochetCount==1)
    //        {
    //            gameObject.GetComponent<LineRenderer>().positionCount++;
    //            gameObject.GetComponent<LineRenderer>().SetPosition(ricochetCount, new Vector3(dir.x*20, dir.y*20, -1));

    //        }
    //        else
    //        {
    //            gameObject.GetComponent<LineRenderer>().positionCount++;
    //            gameObject.GetComponent<LineRenderer>().SetPosition(ricochetCount, new Vector3(origin.x + Vector2.Reflect(lastDir, lastHit).x, origin.y + Vector2.Reflect(lastDir, lastHit).y, -1));

    //        }
    //        StartCoroutine(DisappearLaser());
    //    }
    //}
    //IEnumerator DisappearLaser()
    //{
    //    float timer = Time.time + 1;
    //    while (timer > Time.time)
    //    {
    //        gameObject.GetComponent<LineRenderer>().startColor -= new Color(0, 0, 0, 0.005f);
    //        gameObject.GetComponent<LineRenderer>().endColor -= new Color(0, 0, 0, 0.005f);
    //        yield return null;
    //    }

    //    gameObject.SetActive(false);
    //}
}
