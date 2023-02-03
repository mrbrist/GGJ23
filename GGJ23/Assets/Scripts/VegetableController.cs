using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableController : MonoBehaviour
{
    public SpriteRenderer sr;
    public bool isGrowing = false;

    [SerializeField] private int growthStage;
    [SerializeField] private float growthTime;
    [SerializeField] private int maxSize;

    private float timer;

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
        switch (growthStage)
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
        isGrowing = true;
        growthStage = 0;
    }
}
