using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilding : Building, IColliderAttack
{
    [SerializeField] private List<TowerBuildingSO> towerBuildingSOList;
    [SerializeField] Transform pointToInstantiateBullet;
    [SerializeField] private LayerMask layerToAttack;
    [SerializeField] private TowerBullet bulletPrefab;

    private float cooldownTime;
    private Collider hitCollider;

    TowerBuildingSO towerBuildingSO;

    private void Start()
    {
        towerBuildingSO = towerBuildingSOList[CurrentLevel()];
        cooldownTime = towerBuildingSO.attackSpeed;
    }

    public override void OnUpgradeComplete()
    {
        towerBuildingSO = towerBuildingSOList[CurrentLevel()];
    }
    private void Update()
    {
        if (hitCollider == null)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, towerBuildingSO.radius, layerToAttack);

            if (hitColliders.Length > 0)
            {
                hitCollider = hitColliders[0];
            }
            else
            {
                hitCollider = null;

            }
        } else
        {
            Behavior();
        }
    }

    public Collider GetFirstColliderObject()
    {
        return hitCollider;
    }

    public void Behavior()
    {
        cooldownTime -= Time.deltaTime;
        if(cooldownTime < 0)
        {
            TowerBullet bulletClone = Instantiate(bulletPrefab, pointToInstantiateBullet.position, Quaternion.identity);
            bulletClone.Attack(GetFirstColliderObject(), towerBuildingSO.damage);
            cooldownTime = towerBuildingSOList[CurrentLevel()].attackSpeed; ;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, towerBuildingSOList[0].radius);
    }

}
