using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerBase : MonoBehaviour,IInteractable
{
    [SerializeField] private Transform building;
    [SerializeField] private List<Transform> preview;
    [SerializeField] private CostEachLevelBuildingSO level01;
    [SerializeField] private bool isUnlocked = false;
    private void Start()
    {
        building.GetComponent<Building>().buildingHealth.OnBuildingHealthUnderZero += BuildingHealth_OnBuildingHealthUnderZero;
        Hide(building);
    }

    private void BuildingHealth_OnBuildingHealthUnderZero()
    {
        ResetWhenBuildingDestroyed();
        isUnlocked = false;
    }

    public void Interact()
    {
        if (isUnlocked) return;

        if (EconomyManager.Instance.CanBuyBuilding(level01.cost))
        {
            Show(building.transform);
            Hide(preview);
        }
    }

    void Show(List<Transform> t)
    {
        foreach (Transform item in t)
        {
            item.gameObject.SetActive(true);
        }
    }

    void Hide(List<Transform> t)
    {
        foreach (Transform item in t)
        {
            item.gameObject.SetActive(false);
        }
    }

    void Show(Transform t)
    {
        t.gameObject.SetActive(true);
    }

    void Hide(Transform t)
    {
        t.gameObject.SetActive(false);
    }

    public void InteractAlternate()
    {
        //
    }

    public void ResetWhenBuildingDestroyed()
    {
        Hide(building);
        Show(preview);
    }
}
