using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : Enemy
{
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("/Square");
        HP = 3;
        maxHP = 3;
        colorChange = new Color(0, 0.3f, 0.3f, 0);
        spawnPosition = transform.position;
    }
    void FixedUpdate()
    {
        
        //Move();
    }


    // Update is called once per frame
}
