using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecsPanel : MonoBehaviour
{
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<UIScript>().player.GetComponent<Player>();
    }

}
