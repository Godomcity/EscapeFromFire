using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private GameObject healItemPrefab;

    [Range(0.0f, 1.0f)] public float healItem;
    [Range(0.0f, 1.0f)] public float slowFireItem;

    [SerializeField] ItemProbability[] itemPercentage;

    [System.Serializable]

    public struct ItemProbability
    {
        public string itemName;
        [Range(0f, 1f)] public float itemPercent;
    }

    private float itemSpawnDelay = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnItem());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnValidate()
    {
        float totalPercentage = 0f;
        float overPercent;

        foreach (var item in itemPercentage)
        {
            //totalPercentage += itemPercent;
            totalPercentage += item.itemPercent;
        }

        if (totalPercentage > 1.0f)
        {
            for (int i = 0; i < itemPercentage.Length; i++)
            {
                itemPercentage[i].itemPercent *= (1 / totalPercentage);
            }
        }
    }

    IEnumerator SpawnItem()
    {
        while (true)
        {
            GameObject originalObject = healItemPrefab;
            Vector3 spawnPosition = new Vector3(Random.Range(-8.5f, 8.5f), 5.6f, 0);
            Quaternion spawnRotation = Quaternion.identity;
            GameObject clone = Instantiate(originalObject, spawnPosition, spawnRotation);


            yield return new WaitForSeconds(itemSpawnDelay);
        }

    }


}
