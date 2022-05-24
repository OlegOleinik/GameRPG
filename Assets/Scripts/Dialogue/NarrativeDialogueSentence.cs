using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NarrativeDialogueSentence")]
public class NarrativeDialogueSentence : ADialogueSentence
{
    public ADialogueSentence nextSentence;
    public delegate void OnChoise();
    public event OnChoise onChoise;

    private void Awake()
    {
        type = "Narrative";
    }

    public void DoChoise()
    {
        onChoise?.Invoke();
    }
}
