using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class LaserRicochetAim : MonoBehaviour
{
    private int maxRicochetCount;
    private LayerMask layerMask;
    private int ricochetCount = 0;
    [SerializeField] private LineRenderer aimLine;
    private float laserMaxLength = 10f;
    public void StartAim(int maxCount)
    {
        DontDestroyOnLoad(gameObject);
        maxRicochetCount = maxCount;
        layerMask = LayerMask.GetMask("Wall");
        StartCoroutine(ShootLine());
    }



    void ShootLaser(Vector3 targetPosition, Vector3 direction, float length)
    {
        RaycastHit2D hit = Physics2D.Raycast(targetPosition, direction, length, layerMask);
        Debug.DrawRay(targetPosition, direction * length, Color.black, 10);

        Vector3 endPosition = targetPosition + (length * direction);
        bool isRicochet = false;
        Vector2 newDir = new Vector2(0, 0);
           if (hit.collider!=null && hit.collider.tag == "Wall")
            {
                if (ricochetCount < maxRicochetCount)
                {
                    isRicochet = true;
                    ricochetCount++;
                    newDir = Vector2.Reflect(direction, hit.normal);
                //
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
        LayerMask layerMask = LayerMask.GetMask("Wall");

        while (true)
        {
            ricochetCount = 0;
            aimLine.positionCount = 1;
            float x = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).x - GameManager.player.transform.position.x;
            float y = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).y - GameManager.player.transform.position.y;


            aimLine.SetPosition(0, GameManager.player.transform.position);
            ShootLaser(GameManager.player.transform.position, new Vector3(x, y, -1).normalized, laserMaxLength);


    //        ricochetCount = 0;
    ////  shootLine.SetPosition(0, GameManager.player.transform.position);
    //         float x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - GameManager.player.transform.position.x;
    //        float y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - GameManager.player.transform.position.y;
    //        Vector3 dir = new Vector3(x, y, -1).normalized;
    //        RaycastHit2D hit = Physics2D.Raycast(GameManager.player.transform.position, dir, 15f, layerMask);
    //        if (hit.collider != null)
    //        {
    //            //   shootLine.SetPosition(1, new Vector3(hit.point.x, hit.point.y, -1));
    //        }
    //        else
    //        {
    //            // shootLine.SetPosition(1, GameManager.player.transform.position + (15 * dir));
    //        }
            yield return null;
        }

    }
}
