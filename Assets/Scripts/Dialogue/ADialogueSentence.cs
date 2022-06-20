using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ADialogueSentence : ScriptableObject
{
    public string interlocutorName;
    [TextArea] public string sentence;
    public string type;
}
