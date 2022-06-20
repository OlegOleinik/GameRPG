using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : AEnemy
{
    [SerializeField] private GameObject plantHead;
    [SerializeField] private PlantBullet plantBullet;
    private float rotationVaitTime;
    [SerializeField] private Transform shootPoint;

    public override void Start()
    {
        base.Start();
        plantBullet.GetComponent<PlantBullet>().damage = attack;
        plantBullet.GetComponent<PlantBullet>().repulsion = repulsion;
    }
    protected override void FixedUpdate()
    {
        if (!isSeen)
        {
            RandomRotation();
            return;
        }
        StopAllCoroutines();
        plantHead.transform.rotation = Quaternion.Euler(0, 0, AngleBetweenVector2(plantHead.transform.position, targetList[0].position)-45);
        if (vaitTime < Time.time)
        {
            Shoot();
            vaitTime = Time.time + 2 + Random.Range(0f, 1f);
        }
    }

    private float AngleBetweenVector2(Vector2 pos1, Vector2 pos2)
    {
        Vector2 diference = pos2 - pos1;
        float sign;
        if (pos2.y < pos1.y)
        {
            sign = -1.0f;
        }
        else
        {
            sign = 1.0f;
        }
        return Vector2.Angle(Vector2.right, diference) * sign;
    }

    private void RandomRotation()
    {
        if (rotationVaitTime < Time.time)
        {
            float rnd = Random.Range(-60, 60);
            StartCoroutine((1f.Tweeng((u) => plantHead.transform.rotation = Quaternion.Euler(0, 0, u), plantHead.transform.rotation.eulerAngles.z, plantHead.transform.rotation.eulerAngles.z + rnd)));
            rotationVaitTime = Time.time + 2f + (rnd/100);
        }
    }

    private void Shoot()
    {
        audioSource.Play();
        plantBullet.transform.rotation = Quaternion.Euler(0, 0, plantHead.transform.rotation.eulerAngles.z+45);
        plantBullet.transform.position = shootPoint.position;
        plantBullet.gameObject.SetActive(true);
        plantBullet.StartShoot();
    }

    public override void DieEvent()
    {

    }
}
