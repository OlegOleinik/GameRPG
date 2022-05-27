using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NarrativeDialogueSentence")]
public class NarrativeDialogueSentence : ADialogueSentence
{
    public ADialogueSentence nextSentence;
<<<<<<< Updated upstream
<<<<<<< HEAD
    public delegate void OnChoise();
    public event OnChoise onChoise;
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
    public delegate void OnChoise();
    public event OnChoise onChoise;
>>>>>>> Stashed changes
=======
    public delegate void OnChoise();
    public event OnChoise onChoise;
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
    public delegate void OnChoise();
    public event OnChoise onChoise;
>>>>>>> Stashed changes

    private void Awake()
    {
        type = "Narrative";
    }

<<<<<<< Updated upstream
<<<<<<< HEAD
    public void DoChoise()
    {
        onChoise?.Invoke();
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
    public void DoChoise()
    {
        onChoise?.Invoke();
>>>>>>> Stashed changes
=======
    public void DoChoise()
    {
        onChoise?.Invoke();
>>>>>>> Stashed changes
>>>>>>> 60dc9463f30f4101b954fb049e6ba98c24dc5b76
=======
    public void DoChoise()
    {
        onChoise?.Invoke();
>>>>>>> Stashed changes
    }
}
