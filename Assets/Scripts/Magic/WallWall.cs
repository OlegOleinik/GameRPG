using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WallWall : MonoBehaviour
{
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time + 5f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (timer < Time.time)
        {
            Destroy(gameObject);
        }

    }
}
