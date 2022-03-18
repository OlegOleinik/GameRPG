using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecsPanel : MonoBehaviour
{
    Player player;
    private IncreaseButton[] buttons;
    [SerializeField] Text specspoints;
    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.player.GetComponent<Player>();
        gameObject.SetActive(false);

        buttons = gameObject.GetComponentsInChildren<IncreaseButton>();
    }

    public void IncreaseSpec(int id, float up)
    {
        player.IncreaseSpec(id, up);
        SetText();
    }

    public void SetText()
    {
        Stat[] stats = player.GetStats();
        for (int i = 0; i < stats.Length && i < buttons.Length; i++)
        {
            buttons[i].SetText($" {stats[i].Value}");
        }
        specspoints.text = $"Specs Points {player.specsPoints}";
    }
}
