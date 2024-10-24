using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using static ObjectPool;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]

    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int poolSize;
    }

    public List<Pool> pools = new List<Pool>();
    public Dictionary<string, Queue<GameObject>> PoolDictionary;
    public Dictionary<string, Queue<GameObject>> ActivePoolDictionary;

    private void Awake()
    {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();
        ActivePoolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (var pool in pools)
        {
            GameObject parentObject = new GameObject(pool.prefab.name + "_Pool");
            parentObject.transform.SetParent(this.transform);
            Queue<GameObject> queue = new Queue<GameObject>();
            Queue<GameObject> activeQueue = new Queue<GameObject>();
            for (int i = 0; i < pool.poolSize; i++)
            {
                GameObject obj = Instantiate(pool.prefab, parentObject.transform);
                obj.SetActive(false);
                queue.Enqueue(obj);
            }
            PoolDictionary.Add(pool.tag, queue);
            ActivePoolDictionary.Add(pool.tag, new Queue<GameObject>());
        }
    }

    public GameObject Get(string tag)
    {
        Queue<GameObject> queue = new Queue<GameObject>();
        if (!PoolDictionary.ContainsKey(tag))
        {
            return null;
        }
        GameObject obj = PoolDictionary[tag].Dequeue();
        PoolDictionary[tag].Enqueue(obj);
        obj.SetActive(true);
        queue.Enqueue(obj);
        if (!ActivePoolDictionary.ContainsKey(tag))
        {
            return null;
        }
        ActivePoolDictionary[tag].Enqueue(obj);
        return obj;
    }

    public void Release(GameObject obj)
    {
        obj.SetActive(false);
        PoolDictionary[obj.tag].Enqueue(obj);
        return;
    }

    public void TestGet(string tag)
    {
        Get(tag);
    }

    public void TestRelease(string tag)
    {
        if (ActivePoolDictionary[tag].Count == 0)
        {
            return;
        }
        
        GameObject obj = ActivePoolDictionary[tag].Dequeue();
        Release(obj);
    }
}
