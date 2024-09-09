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
        //for (int i = 0; i < attackBuildingSO.numberOfPeople; i++)
        //{
        //    Troop troop = Instantiate(troopToSpawn, transform.position, Quaternion.identity);
        //    troop.gameObject.SetActive(false);
        //    peopleSpawned.Add(troop);
        //}
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
            //foreach (Troop t in peopleSpawned)
            //{
            //    if (!t.gameObject.activeInHierarchy)
            //    {
            //t.gameObject.SetActive(true);
            //t.transform.position = positionToSpawn.position;
            //Debug.Log("spawn" + t.transform.position);
            //break;
            //    }
            //}
            if (peopleSpawned.Count < attackBuildingSO.numberOfPeople)
            {
                Troop troop = Instantiate(troopToSpawn, transform.position, Quaternion.identity);
                troop.transform.position = positionToSpawn.position;
                peopleSpawned.Add(troop);

            }

            timerToSpawnAgain = attackBuildingSO.timeToSpawnAgain;
        } else
        {
           
        }


    }
}
