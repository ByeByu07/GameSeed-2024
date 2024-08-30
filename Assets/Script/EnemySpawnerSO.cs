using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Spawner SO")]
public class EnemySpawnerSO : ScriptableObject
{
    public int day;
    public List<EnemyInDaySpawnerSO> enemyInDayList;
}
