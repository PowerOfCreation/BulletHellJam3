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

    private Dictionary<int, Stack<GameObject>> disabledGameObjects = new Dictionary<int, Stack<GameObject>>();

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

    public static void Despawn(GameObject gameObjectToDespawn)
    {
        int gameObjectInstance = self.activeGameObjects[gameObjectToDespawn];

        gameObjectToDespawn.SetActive(false);
        gameObjectToDespawn.transform.SetParent(self.transform);

        self.countOfActiveGameObjects[gameObjectInstance]--;
        self.activeGameObjects.Remove(gameObjectToDespawn);
        self.disabledGameObjects[gameObjectInstance].Push(gameObjectToDespawn);
    }

    public static GameObject Spawn(GameObject gameObject, Vector3 position, Transform parent = null)
    {
        GameObject spawnedGameObject = Spawn(gameObject, parent);
        spawnedGameObject.transform.position = position;

        return spawnedGameObject;
    }

    public static GameObject Spawn(GameObject gameObject, Transform parent = null)
    {
        int gameObjectInstance = gameObject.GetInstanceID();

        if(!self.disabledGameObjects[gameObjectInstance].Any()) RefillPool(gameObject, self.countOfActiveGameObjects[gameObjectInstance]);

        GameObject pooledGameObject = self.disabledGameObjects[gameObjectInstance].Pop();
        pooledGameObject.transform.SetParent(parent);
        pooledGameObject.transform.localPosition = Vector3.zero;
        pooledGameObject.gameObject.SetActive(true);

        self.countOfActiveGameObjects[gameObjectInstance]++;
        self.activeGameObjects[pooledGameObject] = gameObjectInstance;

        return pooledGameObject;
    }

    public static void RefillPool(GameObject gameObject, int amountToAdd = 50)
    {
        int gameObjectInstance = gameObject.GetInstanceID();

        Stack<GameObject> spawnedGameObjects = new Stack<GameObject>(amountToAdd);

        for (int i = 0; i < amountToAdd; i++)
        {
            GameObject spawnedGameObject = GameObject.Instantiate(gameObject, self.transform);
            spawnedGameObject.SetActive(false);
            spawnedGameObjects.Push(spawnedGameObject);
        }

        self.disabledGameObjects[gameObjectInstance] = spawnedGameObjects;
    }

    public static void AddPrefabToPooling(GameObject gameObject, int amountToBuffer = 10)
    {
        int gameObjectInstance = gameObject.GetInstanceID();
        
        RefillPool(gameObject, amountToBuffer);

        self.countOfActiveGameObjects[gameObjectInstance] = 0;
    }
}
