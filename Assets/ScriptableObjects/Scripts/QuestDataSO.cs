using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "QuestSO", menuName = "Quests/Default",order =0)]
public class QuestDataSO : ScriptableObject
{

    [Header("Quest Info")]
    public string QuestName;
    public int QuestRequiredLevel;
    public int QuestNPC;

    [Header("¼±Çà Äù½ºÆ®")]
    public List<int> QuestPrerequisites;
}
