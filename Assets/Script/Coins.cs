using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour, IDisposable
{
    public static event Action OnCollideWithPlayer;

    [SerializeField] private Vector2 moveSpeed = new Vector2(5,10);
    private bool isClampToPlayer = false;
    private float randomSpeed;
    void Start()
    {
        Utility.CountDownWithCallback(this, 2f, ClampToPlayer);
    }
    private void ClampToPlayer()
    {
        isClampToPlayer = true;
        randomSpeed = UnityEngine.Random.Range(moveSpeed.x, moveSpeed.y);
    }

    private void Update()
    {
       if (isClampToPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, GameAssets.Instance.player.position + new Vector3(0,1,0), randomSpeed * Time.deltaTime);
        }
    }

    public void Dispose()
    {
        OnCollideWithPlayer = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            OnCollideWithPlayer?.Invoke();
            Destroy(gameObject);
        }
    }
}
