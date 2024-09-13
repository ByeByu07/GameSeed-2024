using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public event Action OnPlayerCollideGameStart;
    [SerializeField] Transform tree;

    private void Start()
    {
        tree.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            OnPlayerCollideGameStart?.Invoke();
            tree.gameObject.SetActive(true);
        }
    }
}
