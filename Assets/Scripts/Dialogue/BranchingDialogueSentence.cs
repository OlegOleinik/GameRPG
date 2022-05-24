using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BranchingDialogueSentence")]
public class BranchingDialogueSentence : ADialogueSentence
{
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    public DialogueChoise[] dialogueChoises;
    private void Awake()
    {
        type = "Branching";
<<<<<<< HEAD
    }
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream

    }

=======
    }
>>>>>>> Stashed changes
=======
    }
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
}

[System.Serializable]
public class DialogueChoise
{
    public string answer;
    public ADialogueSentence nextSentence;
<<<<<<< HEAD
=======
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
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    public delegate void OnChoise();
    public event OnChoise onChoise;

    public void DoChoise()
    {
        onChoise?.Invoke();
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
    }
}