using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Attack Building SO")]
public class AttackBuildingSO : ScriptableObject
{
    public int level;
    public int health;
    public int attackEachPeople;
    public float attackSpeedEachPeople;
    public int healthEachPeople;
    public int numberOfPeople;
    public float timeToSpawnAgain;
}
