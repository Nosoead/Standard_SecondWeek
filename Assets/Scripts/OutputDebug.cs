using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputDebug : MonoBehaviour
{
    private void Start()
    {
        SelectDebug(QuestManager.Instance.questDataSO);
    }

    private void SelectDebug(List<QuestDataSO> questDataSO)
    {
        if (questDataSO.Count == 0)
        {
            return;
        }

        for (int i = 0; i < questDataSO.Count; i++)
        {
            if (questDataSO[i] is EncounterQuestDataSO encounterSO)
            {
                
                Debug.Log($"Quest {encounterSO.QuestNPC} {encounterSO.name} (최소 레벨 {encounterSO.QuestRequiredLevel})");
                Debug.Log($"{encounterSO.targetNPCName}과 대화하기");
            }
            else if (questDataSO[i] is MonsterQuestDataSO monsterSO)
            {
                Debug.Log($"Quest {monsterSO.QuestNPC} {monsterSO.name} (최소 레벨 {monsterSO.QuestRequiredLevel})");
                Debug.Log($"안혜린 매니저님의 꾸준과제를 {monsterSO.targetNumber}마리 소탕");
            }
            else
            {

            }
        }
    }

}
