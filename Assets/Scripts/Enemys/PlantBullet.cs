using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBullet : MonoBehaviour
{
    private float _damage;
    private float _repulsion;

    public float damage
    {
        set
        {
            _damage = value;
        }
    }
    public float repulsion
    {
        set
        {
            _repulsion = value;
        }
    }

    public void StartShoot()
    {
        StartCoroutine(Timer());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            gameObject.SetActive(false);
            return;
        }
        if (collision.tag == "NPC" || collision.tag == "Player")
        {
            IDamagable damagable = collision.GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.GetDamage(_damage, (transform.position + collision.transform.position).normalized * _repulsion * 100);
            }
            StopAllCoroutines();
            gameObject.SetActive(false);
        }
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}
