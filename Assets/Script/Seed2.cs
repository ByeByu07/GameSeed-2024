using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed2 : MonoBehaviour
{
    [SerializeField] Transform tree;

    private void Start()
    {
        tree.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger" + other.name);
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("trigger Plyaer");
            tree.gameObject.SetActive(false);
            GameAssets.Instance.ChangeSeedDestination(GameAssets.Instance.player);
        }
    }
}
