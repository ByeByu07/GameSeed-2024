using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    [SerializeField] Transform tree;

    private void Start()
    {
        tree.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            ModalTopUI.Instance.UpdateTextModal();
            tree.gameObject.SetActive(true);
            Utility.CountDownWithCallback(this, 3f, () => ModalTopUI.Instance.UpdateTextModal());
            GameHandler.Instance.ChangeState(GameHandler.GameState.WaitingCountDownTimer);
            GameAssets.Instance.ChangeSeedDestination(transform);
        }
    }
}
