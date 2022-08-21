using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    /// <summary>
    // Wave Ref


    // 00 min // Tier 1 Mob
    // 01 min // Increase Spawn Rate
    // 02 min // Tier 1 + 2 Mob
    // 03 min // Increase Spawn Rate
    // 04 min // Tier 1 + 2 + 3 Mob

    // 05 min // 'Boss' Mob 1 //
    // 06 min // Increase Spawn Rate
    // 07 min // Tier 2 + 3 Mob
    // 08 min // Increase Spawn Rate
    // 09 min // Tier 2 + 3 + 4 Mob

    // 10 min // 'Boss' Mob 2 //
    // 11 min // Increase Spawn Rate
    // 12 min // Tier 3 + 4 Mob
    // 13 min // Increase Spawn Rate
    // 14 min // Tier 3 + 4 + 5 Mob

    // 15 min // 'Boss' Mob 3 //
    // 16 min // Increase Spawn Rate
    // 17 min // Tier 5 + 6 + 7 Mob
    // 18 min // Increase Spawn Rate
    // 19 min // Increase Spawn Rate

    // Despawn all enemies //
    // 20 min // Reaper Mob - HIGH HP + SUPER FAST //


    //
    /// </summary>

    [Space(8)]
    public Transform[] spawnPos;

    [Space(8)]
    public GameObject mobTier1;
    public GameObject mobTier2;
    public GameObject mobTier3;
    public GameObject mobTier4;
    public GameObject mobTier5;
    public GameObject mobTier6;
    public GameObject mobTier7;

    [Space(8)]
    public GameObject boss1;
    public GameObject boss2;
    public GameObject boss3;
    int currBoss = 0;

    [Space(8)]
    public GameObject reaper;

    [Space(8)]
    public float timeElapsed;
    public float currSpawnTimer = 0f;

    [Space(8)]
    public float spawnInterval = 5f;
    public float spawnTimerMultiplier = 1f;
    int spawnRobin = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime * Time.timeScale;
        currSpawnTimer += Time.deltaTime * Time.timeScale * spawnTimerMultiplier;

        if(currSpawnTimer > spawnInterval)
        {
            Spawn();
            currSpawnTimer = 0f;
        }

        UpdateSpawnBoss();
    }

    void Spawn()
    {
        if(timeElapsed < (1 * 60))
        {
            Instantiate(mobTier1, spawnPos[spawnRobin].position, Quaternion.identity);
        }
        else if (timeElapsed < (2 * 60))
        {
            Instantiate(mobTier1, spawnPos[spawnRobin].position, Quaternion.identity);
            spawnTimerMultiplier = 1.2f;
        }
        else if (timeElapsed < (3 * 60))
        {
            if(spawnRobin % 2 == 0)
                Instantiate(mobTier1, spawnPos[spawnRobin].position, Quaternion.identity);
            else
                Instantiate(mobTier2, spawnPos[spawnRobin].position, Quaternion.identity);
        }
        else if (timeElapsed < (4 * 60))
        {
            if (spawnRobin % 2 == 0)
                Instantiate(mobTier1, spawnPos[spawnRobin].position, Quaternion.identity);
            else
                Instantiate(mobTier2, spawnPos[spawnRobin].position, Quaternion.identity);
            spawnTimerMultiplier = 1.4f;
        }
        else if (timeElapsed < (6 * 60))
        {
            if (spawnRobin % 3 == 0)
                Instantiate(mobTier1, spawnPos[spawnRobin].position, Quaternion.identity);
            else if (spawnRobin % 3 == 1)
                Instantiate(mobTier2, spawnPos[spawnRobin].position, Quaternion.identity);
            else
                Instantiate(mobTier3, spawnPos[spawnRobin].position, Quaternion.identity);
        }
        else if (timeElapsed < (7 * 60))
        {
            if (spawnRobin % 3 == 0)
                Instantiate(mobTier1, spawnPos[spawnRobin].position, Quaternion.identity);
            else if (spawnRobin % 3 == 1)
                Instantiate(mobTier2, spawnPos[spawnRobin].position, Quaternion.identity);
            else
                Instantiate(mobTier3, spawnPos[spawnRobin].position, Quaternion.identity);
            spawnTimerMultiplier = 1.6f;
        }
        else if (timeElapsed < (8 * 60))
        {
            if (spawnRobin % 3 == 0)
                Instantiate(mobTier1, spawnPos[spawnRobin].position, Quaternion.identity);
            else if (spawnRobin % 3 == 1)
                Instantiate(mobTier2, spawnPos[spawnRobin].position, Quaternion.identity);
            else
                Instantiate(mobTier3, spawnPos[spawnRobin].position, Quaternion.identity);
        }
        else if (timeElapsed < (9 * 60))
        {
            if (spawnRobin % 3 == 0)
                Instantiate(mobTier1, spawnPos[spawnRobin].position, Quaternion.identity);
            else if (spawnRobin % 3 == 1)
                Instantiate(mobTier2, spawnPos[spawnRobin].position, Quaternion.identity);
            else
                Instantiate(mobTier3, spawnPos[spawnRobin].position, Quaternion.identity);
            spawnTimerMultiplier = 1.8f;
        }
        else if (timeElapsed < (11 * 60))
        {
            if (spawnRobin % 3 == 0)
                Instantiate(mobTier2, spawnPos[spawnRobin].position, Quaternion.identity);
            else if (spawnRobin % 3 == 1)
                Instantiate(mobTier3, spawnPos[spawnRobin].position, Quaternion.identity);
            else
                Instantiate(mobTier4, spawnPos[spawnRobin].position, Quaternion.identity);
        }
        else if (timeElapsed < (12 * 60))
        {
            if (spawnRobin % 3 == 0)
                Instantiate(mobTier2, spawnPos[spawnRobin].position, Quaternion.identity);
            else if (spawnRobin % 3 == 1)
                Instantiate(mobTier3, spawnPos[spawnRobin].position, Quaternion.identity);
            else
                Instantiate(mobTier4, spawnPos[spawnRobin].position, Quaternion.identity);
            spawnTimerMultiplier = 2.0f;
        }
        else if (timeElapsed < (13 * 60))
        {
            if (spawnRobin % 2 == 0)
                Instantiate(mobTier3, spawnPos[spawnRobin].position, Quaternion.identity);
            else
                Instantiate(mobTier4, spawnPos[spawnRobin].position, Quaternion.identity);
        }
        else if (timeElapsed < (14 * 60))
        {
            if (spawnRobin % 2 == 0)
                Instantiate(mobTier3, spawnPos[spawnRobin].position, Quaternion.identity);
            else
                Instantiate(mobTier4, spawnPos[spawnRobin].position, Quaternion.identity);
            spawnTimerMultiplier = 2.2f;
        }
        else if (timeElapsed < (16 * 60))
        {
            if (spawnRobin % 3 == 0)
                Instantiate(mobTier3, spawnPos[spawnRobin].position, Quaternion.identity);
            else if (spawnRobin % 3 == 1)
                Instantiate(mobTier4, spawnPos[spawnRobin].position, Quaternion.identity);
            else
                Instantiate(mobTier5, spawnPos[spawnRobin].position, Quaternion.identity);
        }
        else if (timeElapsed < (17 * 60))
        {
            if (spawnRobin % 3 == 0)
                Instantiate(mobTier3, spawnPos[spawnRobin].position, Quaternion.identity);
            else if (spawnRobin % 3 == 1)
                Instantiate(mobTier4, spawnPos[spawnRobin].position, Quaternion.identity);
            else
                Instantiate(mobTier5, spawnPos[spawnRobin].position, Quaternion.identity);
            spawnTimerMultiplier = 2.5f;
        }
        else if (timeElapsed < (18 * 60))
        {
            if (spawnRobin % 3 == 0)
                Instantiate(mobTier6, spawnPos[spawnRobin].position, Quaternion.identity);
            else if (spawnRobin % 3 == 1)
                Instantiate(mobTier7, spawnPos[spawnRobin].position, Quaternion.identity);
            else
                Instantiate(mobTier5, spawnPos[spawnRobin].position, Quaternion.identity);
        }
        else if (timeElapsed < (19 * 60))
        {
            if (spawnRobin % 3 == 0)
                Instantiate(mobTier6, spawnPos[spawnRobin].position, Quaternion.identity);
            else if (spawnRobin % 3 == 1)
                Instantiate(mobTier7, spawnPos[spawnRobin].position, Quaternion.identity);
            else
                Instantiate(mobTier5, spawnPos[spawnRobin].position, Quaternion.identity);
            spawnTimerMultiplier = 3.0f;
        }
        else if (timeElapsed < (20 * 60))
        {
            if (spawnRobin % 3 == 0)
                Instantiate(mobTier6, spawnPos[spawnRobin].position, Quaternion.identity);
            else if (spawnRobin % 3 == 1)
                Instantiate(mobTier7, spawnPos[spawnRobin].position, Quaternion.identity);
            else
                Instantiate(mobTier5, spawnPos[spawnRobin].position, Quaternion.identity);
            spawnTimerMultiplier = 4.0f;
        }
        else
        {
            Instantiate(reaper, spawnPos[spawnRobin].position, Quaternion.identity);
        }

        ++spawnRobin;
        if (spawnRobin > 7)
            spawnRobin = 0;
    }

    void UpdateSpawnBoss()
    {
        if(currBoss == 0 && timeElapsed > (5 * 60))
        {
            Instantiate(boss1, spawnPos[spawnRobin].position, Quaternion.identity);
            currBoss = 1;
        }

        if (currBoss == 1 && timeElapsed > (10 * 60))
        {
            Instantiate(boss2, spawnPos[spawnRobin].position, Quaternion.identity);
            currBoss = 2;
        }

        if (currBoss == 2 && timeElapsed > (15 * 60))
        {
            Instantiate(boss3, spawnPos[spawnRobin].position, Quaternion.identity);
            currBoss = 3;
        }

        if (currBoss == 3 && timeElapsed > (20 * 60))
        {
            for(int i = 0; i < 8; ++i)
                Instantiate(reaper, spawnPos[i].position, Quaternion.identity);
            currBoss = 4;
        }
    }
}
