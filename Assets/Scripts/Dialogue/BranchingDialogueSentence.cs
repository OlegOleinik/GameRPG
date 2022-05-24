using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BranchingDialogueSentence")]
public class BranchingDialogueSentence : ADialogueSentence
{
<<<<<<< Updated upstream
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    public DialogueChoise[] dialogueChoises;
    private void Awake()
    {
        type = "Branching";
<<<<<<< Updated upstream
<<<<<<< Updated upstream

    }

=======
    }
>>>>>>> Stashed changes
=======
    }
>>>>>>> Stashed changes
}

[System.Serializable]
public class DialogueChoise
{
    public string answer;
    public ADialogueSentence nextSentence;
<<<<<<< Updated upstream
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
=======
>>>>>>> Stashed changes
    public delegate void OnChoise();
    public event OnChoise onChoise;

    public void DoChoise()
    {
        onChoise?.Invoke();
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    }
}