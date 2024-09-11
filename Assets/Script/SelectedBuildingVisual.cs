using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedBuildingVisual : MonoBehaviour
{
    public Building building;
    public Transform[] selectedBuilding;

    private void Start()
    {
        Hide();
        Player.Instance.OnSelectedBuildingChanged += Player_OnSelectedBuildingChanged;
    }

    private void Player_OnSelectedBuildingChanged(object sender, Player.OnSelectedBuildingChangedEventHandler e)
    {

        if (building.GetComponent<IInteractable>() == e.building) { 
            if(building.IsActive())
            {
            Hide();
            } else
            {
            Show();
            }
        }
    }

    void Show()
    {
        foreach (Transform item in selectedBuilding)
        {
            item.gameObject.SetActive(true);
        }
    }

    void Hide()
    {
        foreach (Transform item in selectedBuilding)
        {
            item.gameObject.SetActive(false);
        }
    }
}
