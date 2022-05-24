using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NarrativeDialogueSentence")]
public class NarrativeDialogueSentence : ADialogueSentence
{
    public ADialogueSentence nextSentence;
<<<<<<< Updated upstream
=======
    public delegate void OnChoise();
    public event OnChoise onChoise;
>>>>>>> Stashed changes

    private void Awake()
    {
        type = "Narrative";
    }

<<<<<<< Updated upstream


    public delegate void OnChoise();
    public event OnChoise onChoise;


    //public delegate void SetStartSentence(int i, ADialogueSentence sentence);
    //public event SetStartSentence setStartSentence;

    public void DoChoise()
    {
        onChoise?.Invoke();
        //setStartSentence?.DynamicInvoke();

=======
    public void DoChoise()
    {
        onChoise?.Invoke();
>>>>>>> Stashed changes
    }
}
