using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private GameObject healItemPrefab;

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
