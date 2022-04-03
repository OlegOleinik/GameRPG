using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MagicUpPanel : MonoBehaviour, ISerializationCallbackReceiver
{
    private Dictionary<MagicScriptableObject, int> magicLevels;

    [SerializeField] private List<MagicScriptableObject> _keys;
    [SerializeField] private List<int> _values;

    private MagicUpCell[] magicUpCells;

    //Unity doesn't know how to serialize a Dictionary
    //public Dictionary<int, string> _myDictionary = new Dictionary<int, string>();
    public void OnBeforeSerialize()
    {

    }

    public void OnAfterDeserialize()
    {
        magicLevels = new Dictionary<MagicScriptableObject, int>();

        for (int i = 0; i != System.Math.Min(_keys.Count, _values.Count); i++)
            magicLevels.Add(_keys[i], _values[i]);
    }
    private void Start()
    {
        magicUpCells = GetComponentsInChildren<MagicUpCell>();
        gameObject.SetActive(false);
    }

    public void DrawPanel()
    {
        for (int i = 0; i < System.Math.Min(magicUpCells.Length, magicLevels.Count); i++)
        {
            magicUpCells[i].DrawCell(magicLevels.ElementAt(i).Key, magicLevels.ElementAt(i).Value);
        }
    }

    public int GetSpellLvl(MagicScriptableObject spell)
    {
       // Debug.Log(magicLevels[spell]);
        return magicLevels[spell];
    }

    public void UpSpellLvl(MagicScriptableObject spell)
    {
        if (magicLevels[spell]<5 && magicLevels[spell]*70<GameManager.player.GetComponent<Player>().money)
        {
            GameManager.player.GetComponent<Player>().money -= magicLevels[spell] * 70;
            magicLevels[spell]++;
            DrawPanel();
        }
    }
}
