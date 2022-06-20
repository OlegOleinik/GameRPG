using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MagicUpPanel : APanel, ISerializationCallbackReceiver
{
    private Dictionary<MagicScriptableObject, int> magicLevels;
    [SerializeField] private List<MagicScriptableObject> _keys;
    [SerializeField] private List<int> _values;
    private MagicUpCell[] magicUpCells;
    [SerializeField] private Text money;
    [SerializeField] private ItemDescription magicDescription;

    public List<int> GetLvls()
    {
        List<int> lvls = new List<int>();
        foreach (var item in magicLevels)
        {
            lvls.Add(item.Value);
        }
        return lvls;
    }
    public void SetLvls(List<int> lvls)
    {
        _values = lvls;
        OnAfterDeserialize();
    }

    public void SetDefaultLvls()
    {
        for (int i = 0; i < _values.Count; i++)
        {
            _values[i] = 1;
        }
        OnAfterDeserialize();
    }

    public void OnBeforeSerialize()
    {

    }

    public void OnAfterDeserialize()
    {
        magicLevels = new Dictionary<MagicScriptableObject, int>();

        for (int i = 0; i != System.Math.Min(_keys.Count, _values.Count); i++)
        {
            magicLevels.Add(_keys[i], _values[i]);
        }
    }
    private void Start()
    {
        magicUpCells = GetComponentsInChildren<MagicUpCell>();
        gameObject.SetActive(false);
    }

    public void DrawPanel()
    {
        money.text = $"{GameManager.player.GetComponent<Player>().money}";
        for (int i = 0; i < System.Math.Min(magicUpCells.Length, magicLevels.Count); i++)
        {
            magicUpCells[i].DrawCell(magicLevels.ElementAt(i).Key, magicLevels.ElementAt(i).Value);
        }
    }

    public int GetSpellLvl(MagicScriptableObject spell)
    {
        return magicLevels[spell];
    }

    public void UpSpellLvl(MagicScriptableObject spell)
    {
        if (magicLevels[spell]<5 && magicLevels[spell]*70<GameManager.player.GetComponent<Player>().money)
        {
            GameManager.ClickPlay();
            GameManager.player.GetComponent<Player>().money -= magicLevels[spell] * 70;
            magicLevels[spell]++;
            DrawPanel();
        }
    }

    public void SetDescription(AMagicCell cell)
    {
        if (cell.magic != null)
        {
            MagicScriptableObject magic = cell.magic;
            string text = magic.description;
            magicDescription.SetDescription(text);
        }
    }


    public void ClearDescription()
    {
        magicDescription.ClearDescription();
    }

    public override void OpenPanel()
    {
        DrawPanel();
    }
}
