using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicCellsPanel : MonoBehaviour
{
    private MagicCell[] magicCells;
    public MagicCell selectedCell = null;
    private KeyCode[] numberKeys = new KeyCode[] { KeyCode.Alpha1,
    KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9 };
    private GameObject activeSpell;
    //
    //
    //
    //DELITE AFTER TESTS
    [SerializeField] MagicScriptableObject spell1;
    [SerializeField] MagicScriptableObject spell2;
    [SerializeField] MagicScriptableObject spell3;
    [SerializeField] MagicScriptableObject spell4;
    //*********
    //
    //
    //
    //
    [SerializeField] Text text;
    bool isDisappearingText = false;
    private float timer;
    private void Start()
    {
        magicCells = gameObject.GetComponentsInChildren<MagicCell>();
        for (int i = 0; i < magicCells.Length; i++)
        {
            magicCells[i].ClearCell();
            magicCells[i].id = i;
        }
        ChangeSelected(magicCells[0]);
        magicCells[0].DrawCell(spell1);
        magicCells[1].DrawCell(spell2);
        magicCells[2].DrawCell(spell3);
        magicCells[3].DrawCell(spell4);
        ShowSpellName();

    }

    private void Update()
    {
        CheckSelectControl();
    }

    public float CastSpell()
    {
        if (activeSpell != null)
        {
            //GameObject spell = Instantiate(selectedCell.spell.spell.gameObject);
            //spell.GetComponent<ASpell>().Spell();
            //selectedCell.spell.spell.GetComponent<ASpell>().Spell();
            //activeSpell.SetActive(true);
            activeSpell.GetComponent<ASpell>().Spell();
            return selectedCell.spell.coolDownTime;
        }
        return -1;
    }

    private void CheckSelectControl()
    {
        float mouseWheelAxis = Input.GetAxis("Mouse ScrollWheel");
        if (mouseWheelAxis != 0 && selectedCell != null)
        {
            if (selectedCell.id==0 && mouseWheelAxis<0)
            {
                ChangeSelected(magicCells[8]);
                return;
            }
            else if (selectedCell.id == 8 && mouseWheelAxis > 0)
            {
                ChangeSelected(magicCells[0]);
                return;
            }
            ChangeSelected(magicCells[selectedCell.id+ System.Convert.ToInt32(mouseWheelAxis)]);
            return;
        }
        int keyKode = CheckNumberDown();
        if (keyKode >= 0)
        {
            ChangeSelected(magicCells[keyKode]);
        }

    }

    private int CheckNumberDown()
    {
        for (int i = 0; i < numberKeys.Length; i++)
        {
            if (Input.GetKeyDown(numberKeys[i]))
            {
                return i;
            }
        }
        return -1;
    }

    public void ChangeSelected(MagicCell newCell)
    {
        if (selectedCell != null)
        {
            ClearSelected();
            Destroy(activeSpell);
        }
        selectedCell = newCell;
        selectedCell.selected = true;
        selectedCell.GetComponent<Image>().color = new Color(0.59f, 0.29f, 0.29f, 1);
        if (selectedCell.spell!=null)
        {
            activeSpell = Instantiate(selectedCell.spell.spell.gameObject);
            DontDestroyOnLoad(activeSpell);
            //activeSpell.SetActive(false);
        }

        ShowSpellName();
    }

    private void ShowSpellName()
    {
        if (selectedCell.spell!=null)
        {
            text.color = new Color(0.196f, 0.196f, 0.196f, 1);
            text.text = selectedCell.spell.spellName;
            timer = Time.time + 2;
            if (!isDisappearingText)
            {
                StartCoroutine(DisappearText());
                //StartCoroutine(2f.Tweeng( (u) => text.color = new Color(0,0,0,u), 1f, 0f));
            }

        }
    }


    public void ClearSelected()
    {
        selectedCell.GetComponent<Image>().color = new Color(1f, 0.7f, 0.44f, 1);
        selectedCell.selected = false;
        selectedCell = null;
    }


    IEnumerator DisappearText()
    {
        isDisappearingText = true;
        while (timer > Time.time)
        {
            text.color -= new Color(0, 0, 0, 0.002f);
            yield return null;
        }
        text.color = new Color(0, 0, 0, 0);
        isDisappearingText = false;
    }
}
