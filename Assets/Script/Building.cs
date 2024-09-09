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
    int upgradeTapCount = 0;

    private void Start()
    {
        buildingHealth = GetComponent<BuildingHealth>();
    }

    public void Interact()
    {
        Debug.Log("tap count" + upgradeTapCount);
        Debug.Log("level" + currentLevel);
        Debug.Log(costEachLevelBuildingSOList[CurrentLevel()].countToBuild);
        if (upgradeTapCount == costEachLevelBuildingSOList[CurrentLevel()].countToBuild )
        {
            
            if(!IsLevelMax())
            {
                currentLevel++;
                OnSuccessUpgradeLevel?.Invoke();
                OnUpgradeComplete();
                UpdateVisual();
            }
             
            //if upgrade success, set health to max again

            upgradeTapCount = 0;

        } else
        {
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
    public int CurrentLevel() { return currentLevel - 1; }
}
