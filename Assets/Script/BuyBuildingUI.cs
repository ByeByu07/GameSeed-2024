using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuyBuildingUI : MonoBehaviour
{
    [SerializeField] private ContainerBase cb;
    [SerializeField] private TextMeshProUGUI textCost;
    void Start()
    {
        textCost.text = cb.GetInitialCost().ToString();
    }
}
