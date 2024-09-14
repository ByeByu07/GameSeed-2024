using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerBase : MonoBehaviour,IInteractable
{
    [SerializeField] private Transform building;
    [SerializeField] private List<Transform> preview;
    [SerializeField] private CostEachLevelBuildingSO level01;
    private void Start()
    {
        Hide(building);
    }

    public void Interact()
    {
        if (EconomyManager.Instance.CanBuyBuilding(level01.cost))
        {
            Show(building.transform);
            Hide(transform);
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
    }

    public int GetInitialCost()
    {
        return level01.cost;
    }
}
