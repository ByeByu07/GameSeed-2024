using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class Building : MonoBehaviour
{
    public event Action OnSuccessUpgradeLevel;
    public event Action OnCancelUpgradeLevel;

    public event EventHandler<OnTapUpgradeEventHandler> OnTapUpgrade;
    public class OnTapUpgradeEventHandler : EventArgs { public int tapCount; }

    public BuildingHealth buildingHealth;
    [SerializeField] private int currentLevel = 1;
    [SerializeField] private int maxLevel = 3;
    public List<CostEachLevelBuildingSO> costEachLevelBuildingSOList;
    int upgradeTapCount = 0;

    public void Interact()
    {
        
        if (costEachLevelBuildingSOList[currentLevel - 1].countToBuild == upgradeTapCount)
        {
            
            if(!IsLevelMax())
            {
                currentLevel++;
            }

            //if upgrade success, set health to max again

            OnSuccessUpgradeLevel?.Invoke();
            OnUpgradeComplete();
            upgradeTapCount = 0;

        } else
        {
            OnTapUpgrade?.Invoke(this, new OnTapUpgradeEventHandler { tapCount = upgradeTapCount });
            upgradeTapCount++;
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

    public bool IsLevelMax() {  return currentLevel == maxLevel; }
    public int CurrentLevel() { return currentLevel - 1; }
}
