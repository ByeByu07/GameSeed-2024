using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

[RequireComponent(typeof(BuildingHealth))]
public class Building : MonoBehaviour, IInteractable
{
    public event Action OnSuccessUpgradeLevel;
    public event Action OnCancelUpgradeLevel;

    public event EventHandler<OnTapUpgradeEventHandler> OnTapUpgrade;
    public class OnTapUpgradeEventHandler : EventArgs { public int tapCount; }

    [HideInInspector] public BuildingHealth buildingHealth;
    [SerializeField] private int currentLevel = 1;
    [SerializeField] private int maxLevel = 3;
    public List<CostEachLevelBuildingSO> costEachLevelBuildingSOList;
    [SerializeField] private List<Transform> GameObjectVisualBasedLevel;
    protected Vector3 originalLocalScale = Vector3.one;
    int upgradeTapCount = 0;

    private void Awake()
    {
        buildingHealth = GetComponent<BuildingHealth>();
    }
    public void Interact()
    {
        if (upgradeTapCount == costEachLevelBuildingSOList[CurrentLevel()].countToBuild )
        {
            if(EconomyManager.Instance.CanBuyBuilding(costEachLevelBuildingSOList[CurrentLevel()].cost))
            {
                if(!IsLevelMax())
                {
                    currentLevel++;
                    OnSuccessUpgradeLevel?.Invoke();
                    OnUpgradeComplete();
                    UpdateVisual();
                }
            }
            //if upgrade success, set health to max again

            upgradeTapCount = 0;

        } else
        {
            transform.DOComplete();
            transform.DOShakeScale(0.3f, 0.5f, 5, 180, true).OnKill(() => { if (transform) { transform.localScale = originalLocalScale; } });
            upgradeTapCount++;
            OnTapUpgrade?.Invoke(this, new OnTapUpgradeEventHandler { tapCount = upgradeTapCount / costEachLevelBuildingSOList[CurrentLevel()].countToBuild });
        }
    }

    public void InteractAlternate()
    {
        OnCancelUpgradeLevel?.Invoke();
    }

    public virtual void OnUpgradeComplete()
    {
        throw new NotImplementedException();
    }
    public void UpdateVisual()
    {
        foreach(Transform t in GameObjectVisualBasedLevel)
        {
            t.gameObject.SetActive(false);
        }

        Transform visual = GameObjectVisualBasedLevel[CurrentLevel()];
        visual.gameObject.SetActive(true);
    }

    public bool IsLevelMax() {  return currentLevel == maxLevel; }
    public bool IsActive() { return currentLevel != 0; }
    public int CurrentLevel() { return currentLevel - 1 ; }
}
