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
                
                Debug.Log($"Quest {encounterSO.QuestNPC} {encounterSO.name} (�ּ� ���� {encounterSO.QuestRequiredLevel})");
                Debug.Log($"{encounterSO.targetNPCName}�� ��ȭ�ϱ�");
            }
            else if (questDataSO[i] is MonsterQuestDataSO monsterSO)
            {
                Debug.Log($"Quest {monsterSO.QuestNPC} {monsterSO.name} (�ּ� ���� {monsterSO.QuestRequiredLevel})");
                Debug.Log($"������ �Ŵ������� ���ذ����� {monsterSO.targetNumber}���� ����");
            }
            else
            {

            }
        }
    }

}
