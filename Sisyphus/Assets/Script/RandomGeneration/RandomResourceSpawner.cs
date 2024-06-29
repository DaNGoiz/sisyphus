using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomResourceSpawner : MonoBehaviour
{
    public GameObject[] spawnedPrefabs;
    public GameObject clearanceProp;
    public int numberOfGenerations;
    public float spawnRange = 5f;
    public float avoidance = 1f;

    public bool canSpawnProb;

    private void Awake()
    {
        if (avoidance > spawnRange)
        {
            avoidance = 1f;
        }
        for (int i = 0; i < numberOfGenerations; i++)
        {
            float ranX = Random.Range(-spawnRange, spawnRange);
            float ranY = Random.Range(-spawnRange, spawnRange);

            
            while ((ranX > 0 && ranX < avoidance) || (ranX < 0 && -ranX < avoidance) || (ranY > 0 && ranY < avoidance) || (ranY < 0 && -ranY < avoidance))
            {
                ranX = Random.Range(-spawnRange, spawnRange);
                ranY = Random.Range(-spawnRange, spawnRange);
            }
            

            int rand = Random.Range(0, spawnedPrefabs.Length);
            Instantiate(spawnedPrefabs[rand], new Vector3(ranX, ranY, 0), Camera.main.transform.rotation, gameObject.transform);
        }

        //生成任务零件

        if (canSpawnProb)
        {
            for (int i = 0; i < 3; i++)
            {
                float ranX = Random.Range(-spawnRange * 0.7f, spawnRange * 0.7f);
                float ranY = Random.Range(-spawnRange * 0.7f, spawnRange * 0.7f);

                while ((ranX > 0 && ranX < avoidance) || (ranX < 0 && -ranX < avoidance) || (ranY > 0 && ranY < avoidance) || (ranY < 0 && -ranY < avoidance))
                {
                    ranX = Random.Range(-spawnRange * 0.7f, spawnRange * 0.7f);
                    ranY = Random.Range(-spawnRange * 0.7f, spawnRange * 0.7f);
                }
                Instantiate(clearanceProp, new Vector3(ranX, ranY, 0), Camera.main.transform.rotation, gameObject.transform);
                //标记三个任务零件的位置并用箭头指向其所在坐标

            }
        }
        
    }
}
