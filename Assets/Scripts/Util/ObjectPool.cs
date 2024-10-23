using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    private List<GameObject> pool = new List<GameObject>();
    public int poolSize = 300;

    void Start()
    {   // 미리 poolSize만큼 게임오브젝트를 생성한다.

        for (int i = 0; i < poolSize; i++)
        {
            Debug.Log(i);
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject Get()
    {
        Debug.Log(pool.Count);
        foreach (var obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                Debug.Log("inForeach " + pool.Count);
                return obj;
            }
        }

        GameObject obj2 = Instantiate(prefab);
        obj2.SetActive(true);
        pool.Add(obj2);
        Debug.Log(pool.Count);
        return obj2;
    }

    public void Release(GameObject obj)
    {
        obj.SetActive(false);
        return;
    }

    public void TestGet()
    {
        Debug.Log("Get");
        Get();
    }

    public void TestRelease()
    {
        Debug.Log("Release");
        foreach (var obj in pool)
        {
            if (obj.activeInHierarchy)
            {
                Release(obj);
                return;
            }
        }
    }
}
