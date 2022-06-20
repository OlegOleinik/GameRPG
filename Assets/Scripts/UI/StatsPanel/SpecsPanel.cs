using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecsPanel : APanel
{
    Player player;
    private IncreaseButton[] buttons;
    [SerializeField] Text specspoints;
    void Start()
    {
        player = GameManager.player.GetComponent<Player>();
        gameObject.SetActive(false);
        buttons = gameObject.GetComponentsInChildren<IncreaseButton>();
    }

    public void IncreaseSpec(int id, float up)
    {
        GameManager.ClickPlay();
        player.IncreaseSpec(id, up);
        SetButtons();
    }

    public void SetButtons()
    {
        int specPoints = player.specsPoints;
        bool isButtonsInteractible = specPoints > 0;
        Stat[] stats = player.GetStats();
        for (int i = 0; i < stats.Length && i < buttons.Length; i++)
        {
            if (stats[i].Value >= stats[i].maxValue)
            {
                buttons[i].SetMax($"{stats[i].Value}");
            }
            else
            {
                buttons[i].SetText($"{stats[i].Value}/{stats[i].maxValue}");
                buttons[i].SetInteractible(isButtonsInteractible);
            }
        }
        specspoints.text = $"Очки навыков: {specPoints}";
    }

    public override void OpenPanel()
    {
        SetButtons();
    }
}
