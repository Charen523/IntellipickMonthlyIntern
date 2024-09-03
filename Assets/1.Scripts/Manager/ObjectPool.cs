using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Pool
{
    public string tag;
    public GameObject prefab;
    public int MinCount;
    public int MaxCount;    
}
public class ObjectPool : Singleton<ObjectPool>
{
    public List<Pool> pools; 
    private Dictionary<string, Queue<MonoBehaviour>> poolDictionary = new Dictionary<string, Queue<MonoBehaviour>>();
    private Transform objectPoolParent;

    private void Start()
    {
        objectPoolParent = new GameObject("ObjectPool").transform;

        foreach (Pool pool in pools)
        {
            CreatePool(pool);
        }
    }

    private void CreatePool(Pool pool)
    {
        Queue<MonoBehaviour> objectPool = new Queue<MonoBehaviour>();
        Transform tagParent = new GameObject(pool.tag).transform;
        tagParent.SetParent(objectPoolParent);

        for (int i = 0; i < pool.MinCount; i++)
        {
            GameObject obj = Instantiate(pool.prefab, tagParent);
            MonoBehaviour objInstance = obj.GetComponent<MonoBehaviour>();
            objInstance.gameObject.SetActive(false);
            objectPool.Enqueue(objInstance);
        }

        poolDictionary.Add(pool.tag, objectPool);
    }

    public T Get<T>(string tag) where T : MonoBehaviour 
    {
        if (!poolDictionary.ContainsKey(tag)) return default;

        MonoBehaviour obj;
        obj = poolDictionary[tag].Dequeue();
        poolDictionary[tag].Enqueue(obj);

        obj.gameObject.SetActive(true);
        return (T)obj;
    }
}
