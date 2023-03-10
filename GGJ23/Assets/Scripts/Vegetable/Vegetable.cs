using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Vegatable", menuName = "Vegatable")]
public class Vegetable : ScriptableObject
{
    public new string name;

    public Sprite seed;
    public Sprite finalProduct;
    public Sprite[] growthSprites;
    public Sprite shopImage;

    public int worthPer;
    public int seedCost;

    public bool isGrowing = false;

    public int growthStage;
    public float growthTime;
    public int maxSize;

    public bool stackable = true;
}
