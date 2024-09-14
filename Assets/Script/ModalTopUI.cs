using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ModalTopUI : MonoBehaviour
{
    public static ModalTopUI Instance { get; private set; }

    [SerializeField] TextMeshProUGUI modalText;
    [SerializeField] List<ModalTopUISO> modalTopUISOs;
    [SerializeField] private int amount = 0;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        modalText.text = modalTopUISOs[amount].text;
    }

    public void UpdateTextModal()
    {
        amount++;
        Debug.Log(amount);
        if (amount >= modalTopUISOs.Count)
        {
            Debug.Log("max modal");
            gameObject.SetActive(false);
            return;
        }

        modalText.text = modalTopUISOs[amount].text;
    }

}
