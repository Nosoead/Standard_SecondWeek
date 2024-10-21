using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    private static QuestManager instance;

    public QuestManager Instance
    {
        get { return instance; }
        set
        {
            if (instance == null)
            {
                instance = FindObjectOfType<QuestManager>();
                if (instance == null)
                {
                    GameObject QuestManager = new GameObject();
                    QuestManager.AddComponent<QuestManager>();
                }
            }
        }
    }


}
