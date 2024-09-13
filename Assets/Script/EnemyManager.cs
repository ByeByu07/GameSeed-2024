using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    public List<EnemySpawnerSO> enemySpawnerSOList;
    public List<Transform> pointToSpawn;

    private void Start()
    {
        GameHandler.Instance.OnDayChanged += GameHandler_OnDayChanged;
    }

    private void GameHandler_OnDayChanged(object sender, GameHandler.OnDayChangedEventHandler e)
    {
        EnemySpawnerSO esSO = enemySpawnerSOList[e.day];

        if(esSO == null)
        {
            throw new NotImplementedException();
        }

        foreach (EnemyInDaySpawnerSO enemy in esSO.enemyInDayList)
        {
            Transform location = pointToSpawn[enemy.spawnLocation];

            if(location == null)
            {
                throw new NotImplementedException();
            }

            for (var i = 0; i < enemy.amountToSpawn; i++)
            {
                Utility.CountDownWithCallback(this, Random.Range(0, 3), () => Instantiate(enemy.enemy, location.position, Quaternion.identity));
            }
        }
    }
}
