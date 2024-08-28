using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Cost Building Per Level SO")]
public class CostEachLevelBuildingSO : ScriptableObject
{
    public int level;
    public int cost;
    public int countToBuild;
}
