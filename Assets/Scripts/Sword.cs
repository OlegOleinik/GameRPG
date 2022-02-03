using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    // Start is called before the first frame update
    private bool ableToAttack = true;
    private float coolDownTime;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //���������� TRUE, ���� �������� ����� � ������ ���������� ������� � ����������
    public bool EnableToAttck()
    {
        return (ableToAttack && coolDownTime < Time.time);
    }

    private void SwordDisappear()
    {
        gameObject.SetActive(false);
        coolDownTime = Time.time + 0.5f;
        ableToAttack = true;
    }
    //���� 1
    public void Strike1()
    {
        StartCoroutine(RotateObject());
    }
    //���� 2
    public void Strike2()
    {

    }

    //������������ ���� � ���-����. � ������-����������, �� ������-���������.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Rigidbody2D>().AddForce(5*((collision.transform.position - transform.position).normalized), ForceMode2D.Impulse);
            collision.GetComponent<AEnemy>().GetDamage(1);
        }
        else if (collision.tag == "Wall")
        {
            SwordDisappear();
        }
    }

    //�������� ����. ���� x < 0, �.�. ���� ����� �� ������, �� ��������� � ����� � �������� � +. ��� ����, ����� ����� ������ ��� ������ ����
    IEnumerator RotateObject()
    {
        Quaternion endingAngle;
        float moveSpeed = 450;
        ableToAttack = false;


        float x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        float angle = Mathf.Atan2(Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y, x) * Mathf.Rad2Deg;

        if (x<0)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle -= 60);
            endingAngle = Quaternion.Euler(0, 0, angle + 120);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, angle += 60);
            endingAngle = Quaternion.Euler(0, 0, angle - 120);
        }
        

        while (Quaternion.Angle(transform.rotation, endingAngle) > 0.01)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, endingAngle, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.rotation = endingAngle;
        SwordDisappear();
    }
}
