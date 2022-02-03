using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed;
    public int currentHP;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        DontDestroyOnLoad(gameObject);
    }
    public void GetDamage(int damage)
    {
        currentHP -= damage;
    }
    private void FixedUpdate()
    {
        rb.position += (new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * moveSpeed);
    }
}
