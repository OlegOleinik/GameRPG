using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest Scriptable Object")]
public class QuestScriptableObject : ScriptableObject
{
    public GameObject quest;
    public string questName;
    public string[] stagesDescription;
}


