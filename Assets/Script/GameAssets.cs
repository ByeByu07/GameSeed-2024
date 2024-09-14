using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets Instance { get; private set; }

    [Header("GameObject Assets")]
    public Transform EnemyDead;
    public Transform TowerBulletLandingPage;
    [Header("Audio Assets")]
    public List<AudioClip> playerSteps;
    public Transform player;
    public Transform seed;

    private void Awake()
    {
        Instance = this;
    }

    public void ChangeSeedDestination(Transform t)
    {
        seed = t;
    }
}
