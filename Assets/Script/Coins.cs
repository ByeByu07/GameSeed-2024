using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour, IDisposable
{
    public static event Action OnCollideWithPlayer;

    [SerializeField] private float moveSpeed = 0.5f;
    private bool isClampToPlayer = false;
    //Rigidbody rb;
    void Start()
    {
        Utility.CountDownWithCallback(this, 2f, ClampToPlayer);
        //rb = GetComponent<Rigidbody>();
    }

    private void ClampToPlayer()
    {
        //isClampToPlayer = true;
        transform.DOMove(GameAssets.Instance.player.position, 2f).SetEase(Ease.InOutQuad);
    }

    //private void Update()
    //{
    //    if (isClampToPlayer)
    //    {
    //        transform.position = Vector3.MoveTowards(transform.position, GameAssets.Instance.player.position, moveSpeed * Time.deltaTime);
    //    }
    //}

    public void Dispose()
    {
        OnCollideWithPlayer = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        OnCollideWithPlayer?.Invoke();
        Destroy(gameObject);
    }
}
