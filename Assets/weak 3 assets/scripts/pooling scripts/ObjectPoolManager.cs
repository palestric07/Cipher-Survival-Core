using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager Instance { get; private set; }

    [System.Serializable]
    public class Pool
    {
        public string poolKey;
        public GameObject prefab;
        public int initialSize = 5;
    }

    public List<Pool> pools;
    private Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        InitializePools();
    }

    private void InitializePools()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.initialSize; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                obj.transform.SetParent(transform);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.poolKey, objectPool);
        }
    }

    public GameObject SpawnFromPool(string poolKey, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(poolKey))
        {
            Debug.LogWarning("Pool key not found: " + poolKey);
            return null;
        }

        GameObject objToSpawn;

        if (poolDictionary[poolKey].Count > 0)
        {
            objToSpawn = poolDictionary[poolKey].Dequeue();
        }
        else
        {
            // Expansion fallback if pool runs empty
            Pool pool = pools.Find(p => p.poolKey == poolKey);
            objToSpawn = Instantiate(pool.prefab);
        }

        objToSpawn.transform.position = position;
        objToSpawn.transform.rotation = rotation;
        objToSpawn.SetActive(true);

        return objToSpawn;
    }

    public void ReturnToPool(string poolKey, GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(transform);

        if (poolDictionary.ContainsKey(poolKey))
        {
            poolDictionary[poolKey].Enqueue(obj);
        }
    }
}