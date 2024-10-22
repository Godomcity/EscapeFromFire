using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] ItemProbability[] itemList;
    [SerializeField] private float itemSpawnDelay = 3.0f;

    [SerializeField] private AudioClip healClip;
    [SerializeField] private AudioClip speedUpClip;
    [SerializeField] private AudioClip fireSlowDownClip;
    [SerializeField] AudioSource audioSource;

    [System.Serializable]
    public struct ItemProbability
    {
        [SerializeField] public GameObject item;
        [Range(0f, 1f)] public float itemPercent;
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnItem());
    }
    

    private void OnValidate()
    {
        float totalPercentage = 0f;

        foreach (var item in itemList)
        {
            //totalPercentage += itemPercent;
            totalPercentage += item.itemPercent;
        }

        if (totalPercentage != 1.0f)
        {
            for (int i = 0; i < itemList.Length; i++)
            {
                itemList[i].itemPercent *= (1 / totalPercentage);
            }
        }

    }

    IEnumerator SpawnItem()
    {
        while (true)
        {
            GameObject spawnItem = GetRandomItemBasedOnProbability();

            if (spawnItem == null)
            {
                yield return new WaitForSeconds(itemSpawnDelay);
                continue;
            }

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

        foreach (var item in itemList)
        {
            cumulativeProbability += item.itemPercent;

            if (randomValue <= cumulativeProbability)
            {
                return item.item;
            }
        }

        return null;
    }

    public void UseItem(Item item, GameObject player)
    {
        if (item.name == "HealItem(Clone)")
        {
            audioSource.PlayOneShot(healClip);
        }
        else if (item.name == "FastSpeedItem(Clone)")
        {
            audioSource.PlayOneShot(speedUpClip);
        }
        else
        {
            audioSource.PlayOneShot(fireSlowDownClip);
        }

        // 아이템이 반환한 코루틴을 실행
        StartCoroutine(item.ItemEffect(player));
    }
}
