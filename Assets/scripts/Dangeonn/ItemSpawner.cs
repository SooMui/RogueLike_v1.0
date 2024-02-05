using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [System.Serializable]
    public struct Spawnable
    {
        public GameObject gameObject;
        public float width;
    }

    public List<Spawnable> items = new List<Spawnable>();
    float totalWidth;

    void Awake()
    {
        totalWidth = 0;
        foreach(var spawnable in items)
        {
            totalWidth += spawnable.width;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        float pick = Random.value * totalWidth;
        int chosenIndex = 0;
        float cumulativeWidth = items[0].width;

        while(pick > cumulativeWidth && chosenIndex < items.Count - 1)
        {
            chosenIndex++;
            cumulativeWidth += items[chosenIndex].width;
        }

        GameObject i = Instantiate(items[chosenIndex].gameObject, transform.position, Quaternion.identity) as GameObject;

    }
}