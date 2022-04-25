using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NarrativeDialogueSentence")]
public class NarrativeDialogueSentence : ADialogueSentence
{
    public ADialogueSentence nextSentence;

    private void Awake()
    {
        type = "Narrative";
    }



    public delegate void OnChoise();
    public event OnChoise onChoise;


    //public delegate void SetStartSentence(int i, ADialogueSentence sentence);
    //public event SetStartSentence setStartSentence;

    public void DoChoise()
    {
        onChoise?.Invoke();
        //setStartSentence?.DynamicInvoke();

    }
}
