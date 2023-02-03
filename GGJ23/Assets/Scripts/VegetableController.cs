using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableController : MonoBehaviour
{
    [Header("Sprite Renderer")]
    public SpriteRenderer sr;
    [Header("Vegatable Scritable Object")]
    public Vegetable vg;

    private float timer;

    private bool isGrowing;
    private int growthStage;
    private float growthTime;
    private int maxSize;

    private void Start()
    {
        isGrowing = vg.isGrowing;
        growthStage = vg.growthStage;
        growthTime = vg.growthTime;
        maxSize = vg.maxSize;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        // Grow plant
        if (timer >= growthTime && isGrowing)
        {
            timer = 0f;
            growthStage++;

            if (growthStage >= maxSize)
            {
                growthStage = maxSize;
                isGrowing = false;
            }
        }

        // Change apperance
        if (growthStage != -1)
        {
            sr.sprite = vg.sprites[growthStage];
        }
    }

    private void OnMouseDown()
    {
        isGrowing = true;
        growthStage = 0;
    }
}
