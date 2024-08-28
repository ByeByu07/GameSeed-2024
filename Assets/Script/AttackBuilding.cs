using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackBuilding : Building
{
    [Header("Default Configuration")]
    [SerializeField] Transform positionToSpawn;

    List<AttackBuildingSO> attackBuildingSOList;
    [SerializeField] private AttackBuildingSO attackBuildingSO;

    [Header("Spawn Configuration")]
    List<GameObject> peopleSpawned;
    [SerializeField] private Troop troopToSpawn;
    public float timerToSpawnAgain;

    private void Awake()
    {
        attackBuildingSOList = new List<AttackBuildingSO>();
    }
    private void Start()
    {
        attackBuildingSO = attackBuildingSOList[CurrentLevel()];
        timerToSpawnAgain = attackBuildingSO.timeToSpawnAgain;
    }

    public override void OnUpgradeComplete()
    {
        attackBuildingSO = attackBuildingSOList[CurrentLevel()];
    }


    private void Update()
    {
        timerToSpawnAgain -= Time.deltaTime;
        if(timerToSpawnAgain < 0 && peopleSpawned.Count < attackBuildingSO.numberOfPeople)
        {
            //spawn

            //add to list


            timerToSpawnAgain = attackBuildingSO.timeToSpawnAgain;
        }
    }
}
