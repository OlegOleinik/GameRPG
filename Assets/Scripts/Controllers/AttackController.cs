using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    // Start is called before the first frame update
    public Sword sword;
    void Start()
    {
        sword.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && sword.EnableToAttck() && GameManager.isGamePaused == false)
        {
            sword.gameObject.SetActive(true);
            sword.Strike1();
        }
    }
}
