using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableController : MonoBehaviour
{
    [Header("TO BE REPLACED")]
    public SpriteRenderer sr;
    [Header("Vegatable Scritable Object")]
    public Vegetable vg;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        // Grow plant
        if (timer >= vg.growthTime && vg.isGrowing)
        {
            timer = 0f;
            vg.growthStage++;

            if (vg.growthStage >= vg.maxSize)
            {
                vg.growthStage = vg.maxSize;
                vg.isGrowing = false;
            }
        }

        // Change apperance
        switch (vg.growthStage)
        {
            case 0:
                sr.color = new Color(255, 0, 0, 255);
                break;
            case 2:
                sr.color = new Color(255, 188, 0, 255);
                break;
            case 4:
                sr.color = new Color(0, 255, 0, 255);
                break;
            default:
                break;
        }
    }

    private void OnMouseDown()
    {
        vg.isGrowing = true;
        vg.growthStage = 0;
    }
}
