using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRicochetSpell : ASpell
{
    private LayerMask layerMask;
    private int ricochetCount = 0;
    private Vector2 lastHit;
    private Vector2 lastDir;

    public override void Start()
    {
       
    }
    public override void Spell()
    {
        // Instantiate(gameObject);
        //Debug.DrawRay(new Vector3(0, 0, 0), new Vector3(2, 2, 0), Color.blue, 20);

        float x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - GameManager.player.transform.position.x;

        float y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - GameManager.player.transform.position.y;
        layerMask = LayerMask.GetMask("Wall") + LayerMask.GetMask("Enemys");
        //laser = Instantiate(gameObject);



        gameObject.GetComponent<LineRenderer>().SetPosition(0, new Vector3(GameManager.player.transform.position.x, GameManager.player.transform.position.y, -1));
        CastLaser(GameManager.player.transform.position, new Vector2(x, y));
       // Debug.Log(Input.mousePosition.normalized);
        //RaycastHit2D hit = Physics2D.Raycast(GameManager.player.transform.position, new Vector2(x, y).normalized, 30, layerMask);

       


       // Debug.Log("Laser Pew Pew");
    }

    public void CastLaser(Vector2 origin, Vector2 dir)
    {
        ricochetCount++;




        Debug.DrawRay(origin, dir.normalized * 20, Color.blue, 7);
        //RaycastHit2D[] result;
        //RaycastHit2D hit = Physics2D.RaycastNonAlloc(GameManager.player.transform.position, new Vector2(x, y).normalized, result, 30, layerMask);
        RaycastHit2D[] hit = Physics2D.RaycastAll(origin, dir.normalized, 20, layerMask);
        bool stopLaser = true;

        foreach (var item in hit)
        {
            if (item.collider.tag == "Enemy")
            {
                item.collider.GetComponent<AEnemy>().GetDamage(1);
            }
            else if (item.collider.tag == "Wall" && ricochetCount < 4)
            {
                gameObject.GetComponent<LineRenderer>().positionCount++;
                gameObject.GetComponent<LineRenderer>().SetPosition(ricochetCount, new Vector3(item.point.x, item.point.y, -1));
                lastHit = item.normal;
                lastDir = dir;
                CastLaser(item.point, Vector2.Reflect(dir, item.normal));
                stopLaser = false;
                break;
            }
        }
        if (stopLaser)
        {
            if (ricochetCount==1)
            {
                gameObject.GetComponent<LineRenderer>().positionCount++;
                gameObject.GetComponent<LineRenderer>().SetPosition(ricochetCount, new Vector3(dir.x*20, dir.y*20, -1));

            }
            else
            {
                gameObject.GetComponent<LineRenderer>().positionCount++;
                gameObject.GetComponent<LineRenderer>().SetPosition(ricochetCount, new Vector3(origin.x + Vector2.Reflect(lastDir, lastHit).x, origin.y + Vector2.Reflect(lastDir, lastHit).y, -1));

            }
            StartCoroutine(DisappearLaser());
        }
    }
    IEnumerator DisappearLaser()
    {
        float timer = Time.time+1;
        while (timer>Time.time)
        {
            gameObject.GetComponent<LineRenderer>().startColor -= new Color(0, 0, 0, 0.005f);
            gameObject.GetComponent<LineRenderer>().endColor -= new Color(0, 0, 0, 0.005f);
            yield return null;
        }
        Destroy(gameObject);
    }
}
