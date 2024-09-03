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

        for (int i = 0; i < attackBuildingSO.numberOfPeople; i++)
        {
            Troop troop = Instantiate(troopToSpawn, transform.position, Quaternion.identity);
            troop.gameObject.SetActive(false);
            peopleSpawned.Add(troop);
        }
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
            foreach (Troop t in peopleSpawned)
            {
                if (!t.gameObject.activeInHierarchy)
                {
                    t.transform.position = positionToSpawn.position;
                    t.gameObject.SetActive(true);
                    Debug.Log("spawn");
                    break;
                }
            }

            timerToSpawnAgain = attackBuildingSO.timeToSpawnAgain;
        }
    }
}
