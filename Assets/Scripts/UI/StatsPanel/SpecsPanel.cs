using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecsPanel : MonoBehaviour
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
        Stat[] stats = player.GetStats();
        for (int i = 0; i < stats.Length && i < buttons.Length; i++)
        {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            if (buttons[i].isUpdate)
            {
                buttons[i].SetText($"{stats[i].Value}/{stats[i].maxValue}");
                if (stats[i].Value >= stats[i].maxValue)
                {
                    buttons[i].SetMax($"{stats[i].Value}");
                }
            }

=======
=======
>>>>>>> Stashed changes
            
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
            if (stats[i].Value >= stats[i].maxValue)
            {
                buttons[i].SetMax($"{stats[i].Value}");
            }
            else
            {
                buttons[i].SetText($"{stats[i].Value}/{stats[i].maxValue}");
            }
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
        }
        specspoints.text = $"Specs Points {player.specsPoints}";
    }
}
