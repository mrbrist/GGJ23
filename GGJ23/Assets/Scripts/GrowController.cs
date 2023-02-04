using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowController : MonoBehaviour
{
    [Header("Sprite Renderer")]
    public SpriteRenderer sr;
    [Header("Vegatable Scritable Object")]
    public Vegetable vg;

    private PlayerStats playerStats;

    public Sprite emptyPlot;

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

        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
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
                sr.sprite = vg.growthSprites[growthStage];
                isGrowing = false;
                StartCoroutine(FinishGrowing());
            }
        }

        // Change apperance
        if (growthStage != -1)
        {
            if (isGrowing)
            {
                sr.sprite = vg.growthSprites[growthStage];
            }
        } else
        {
            sr.sprite = emptyPlot;
        }
    }
    IEnumerator FinishGrowing()
    {
        yield return new WaitForSeconds(growthTime);
        sr.sprite = emptyPlot;
        playerStats.money += vg.worthPer;
    }

    private void OnMouseDown()
    {
        if (!isGrowing)
        {
            vg = playerStats.activeVegetable;

            isGrowing = vg.isGrowing;
            growthStage = vg.growthStage;
            growthTime = vg.growthTime;
            maxSize = vg.maxSize;

            isGrowing = true;
            growthStage = 0;
        }
    }
}
