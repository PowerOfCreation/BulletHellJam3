using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class PoolingManagerEntry
{
    public GameObject prefab;
    public int count;
}

public class PoolingManager : MonoBehaviour
{
    public static PoolingManager self;

    private Dictionary<int, List<GameObject>> disabledGameObjects = new Dictionary<int, List<GameObject>>();

    private Dictionary<int, int> countOfActiveGameObjects = new Dictionary<int, int>();

    private Dictionary<GameObject, int> activeGameObjects = new Dictionary<GameObject, int>();

    public List<PoolingManagerEntry> poolingManagerEntries = new List<PoolingManagerEntry>();

    void Awake()
    {
        self = this;

        for (int i = 0; i < poolingManagerEntries.Count; i++)
        {
            AddPrefabToPooling(poolingManagerEntries[i].prefab, poolingManagerEntries[i].count);
        }
    }

    public static void Despawn(GameObject gameObject)
    {
        int gameObjectInstance = self.activeGameObjects[gameObject];

        gameObject.SetActive(false);
        gameObject.transform.SetParent(self.transform);

        self.countOfActiveGameObjects[gameObjectInstance]--;
        self.activeGameObjects.Remove(gameObject);
    }

    public static GameObject Spawn(GameObject gameObject, Transform parent)
    {
        int gameObjectInstance = gameObject.GetInstanceID();

        if(!self.disabledGameObjects[gameObjectInstance].Any()) RefillPool(gameObject, self.countOfActiveGameObjects[gameObjectInstance]);

        GameObject pooledGameObject = self.disabledGameObjects[gameObjectInstance][0];
        pooledGameObject.transform.SetParent(parent);
        pooledGameObject.gameObject.SetActive(true);

        self.countOfActiveGameObjects[gameObjectInstance]++;
        self.activeGameObjects[pooledGameObject] = gameObjectInstance;

        return pooledGameObject;
    }

    public static void RefillPool(GameObject gameObject, int amountToAdd = 50)
    {
        List<GameObject> spawnedGameObjects = new List<GameObject>(amountToAdd);

        for (int i = 0; i < amountToAdd; i++)
        {
            spawnedGameObjects.Add(GameObject.Instantiate(gameObject, self.transform));
        }

        self.disabledGameObjects[gameObject.GetInstanceID()].Concat(spawnedGameObjects);
    }

    public static void AddPrefabToPooling(GameObject gameObject, int amountToBuffer = 10)
    {
        int gameObjectInstance = gameObject.GetInstanceID();
        
        List<GameObject> spawnedGameObjects = new List<GameObject>(amountToBuffer);

        for (int i = 0; i < amountToBuffer; i++)
        {
            spawnedGameObjects.Add(GameObject.Instantiate(gameObject, self.transform));
        }

        self.disabledGameObjects[gameObjectInstance] = spawnedGameObjects;
        self.countOfActiveGameObjects[gameObjectInstance] = 0;
    }
}
