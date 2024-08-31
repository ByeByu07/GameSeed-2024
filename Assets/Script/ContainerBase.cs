using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerBase : MonoBehaviour,IInteractable
{
    [SerializeField] private Building building;
    [SerializeField] private Transform buildingPreview;
    [SerializeField] private Transform indicator;
    [SerializeField] private bool isUnlocked = false;

    void Start()
    {
        building.OnTapUpgrade += Building_OnTapUpgrade;
        building.OnCancelUpgradeLevel += Building_OnCancelUpgradeLevel;
        building.OnSuccessUpgradeLevel += Building_OnSuccessUpgradeLevel;
        building.buildingHealth.OnBuildingHealthUnderZero += BuildingHealth_OnBuildingHealthUnderZero;
        
        Player.Instance.OnSelectedBuildingChanged += Player_OnSelectedBuildingChanged;

        buildingPreview.gameObject.SetActive(false);
        building.gameObject.SetActive(false);
    }

    private void Player_OnSelectedBuildingChanged(object sender, Player.OnSelectedBuildingChangedEventHandler e)
    {
        if (isUnlocked) return;

        //if (this.GetComponent<IInteractable>() == e.building)
        //{
        //    buildingPreview.gameObject.SetActive(true);
        //}
        //else
        //{
        //    buildingPreview.gameObject.SetActive(false);
        //}
    }


    private void BuildingHealth_OnBuildingHealthUnderZero()
    {
        building.gameObject.SetActive(false);
    }

    private void Building_OnSuccessUpgradeLevel()
    {
        throw new System.NotImplementedException();
    }

    private void Building_OnCancelUpgradeLevel()
    {
        throw new System.NotImplementedException();
    }

    private void Building_OnTapUpgrade(object sender, Building.OnTapUpgradeEventHandler e)
    {
        if (e.tapCount != 0)
        {
            indicator.gameObject.SetActive(false);

            // normalize tapCOunt to 1
            //float a = e.tapCount / 1;
            // get position building y0 ( first position )
            //Vector3 b = building.transform.position;
            // move slowly each tapcount
            // move with dotween up & shake
            //building.transform.DOMove(new Vector3(b.x, b.y + a, b.z),0.3f);
        }
    }

    public void Interact()
    {
        if(!isUnlocked)
        {
            isUnlocked = true;
            indicator.gameObject.SetActive(false);
            buildingPreview.gameObject.SetActive(false);
            building.gameObject.SetActive(true);
        }

        building.transform.DOMoveY(1f, 2f);
        building.transform.DOShakeScale(.5f, .5f, 10, 180,true);
    }

    public void InteractAlternate()
    {
        throw new System.NotImplementedException();
    }

    //void Show()
    //{
    //    foreach (Transform item in selectedBuilding)
    //    {
    //        item.gameObject.SetActive(true);
    //    }
    //}

    //void Hide()
    //{
    //    foreach (Transform item in selectedBuilding)
    //    {
    //        item.gameObject.SetActive(false);
    //    }
    //}
}
