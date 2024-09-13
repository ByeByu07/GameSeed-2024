using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance {  get; private set; }
    [SerializeField] private List<Building> buildingList;

    private void Awake()
    {
        Instance = this;
    }

    public void AddBuilding(Building building)
    {
        buildingList.Add(building);
    }

    public void RemoveBuilding(Building building)
    {
        buildingList.Remove(building);
    }

    public List<Building> GetBuildingActiveList()
    {
        return buildingList;
    }
}
