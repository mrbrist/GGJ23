using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Vegatable", menuName = "Vegatable")]
public class Vegetable : ScriptableObject
{
    public new string name;

    public bool isGrowing = false;

    public int growthStage = -1;
    public float growthTime;
    public int maxSize;
}
