using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestSO", menuName = "Quests/Monster", order = 1)]
public class MonsterQuestDataSO : QuestDataSO
{
    [Header("Quest Requirements")]
    public int targetNumber;
}
