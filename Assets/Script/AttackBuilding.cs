using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackBuilding : Building
{
    [Header("Default Configuration")]
    [SerializeField] Transform positionToSpawn;

    [SerializeField] private List<AttackBuildingSO> attackBuildingSOList;
    [SerializeField] private AttackBuildingSO attackBuildingSO;

    [Header("Spawn Configuration")]
    List<Troop> peopleSpawned;
    [SerializeField] private Troop troopToSpawn;
    private float timerToSpawnAgain;

    private void Awake()
    {
        peopleSpawned = new List<Troop>();
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
        if(timerToSpawnAgain < 0)
        {
            if (peopleSpawned.Count < attackBuildingSO.numberOfPeople)
            {
                Troop troop = Instantiate(troopToSpawn, positionToSpawn.position + new Vector3(Random.Range(4, -4), 0, Random.Range(4, -4)), Quaternion.identity);
                peopleSpawned.Add(troop);
            }

            timerToSpawnAgain = attackBuildingSO.timeToSpawnAgain;
        } else
        {
           
        }


    }
}
