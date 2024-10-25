using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestSO", menuName = "Quests/Encounter", order = 2)]
public class EncounterQuestDataSO : QuestDataSO
{
    [Header("Quest Requirements")]
    public string targetNPCName;
}
