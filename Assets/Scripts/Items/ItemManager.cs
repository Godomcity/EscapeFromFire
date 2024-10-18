using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private GameObject healItemPrefab;

    [SerializeField] ItemProbability[] itemPercentage;


    [System.Serializable]
    public struct ItemProbability
    {
        [SerializeField] public GameObject item;
        [Range(0f, 1f)] public float itemPercent;
    }

    private float itemSpawnDelay = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnItem());
    }
    void Update()
    {
        
    }

    private void OnValidate()
    {
        float totalPercentage = 0f;

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
            GameObject spawnItem = GetRandomItemBasedOnProbability();

            Vector3 spawnPosition = new Vector3(Random.Range(-8.5f, 8.5f), 5.6f, 0);
            Quaternion spawnRotation = Quaternion.identity;

            Instantiate(spawnItem, spawnPosition, spawnRotation);

            yield return new WaitForSeconds(itemSpawnDelay);
        }

    }

    private GameObject GetRandomItemBasedOnProbability()
    {
        float randomValue = Random.Range(0f, 1f);
        float cumulativeProbability = 0f;

        foreach (var item in itemPercentage)
        {
            cumulativeProbability += item.itemPercent;

            if (randomValue <= cumulativeProbability)
            {
                return item.item;
            }
        }

        return null;
    }
}
