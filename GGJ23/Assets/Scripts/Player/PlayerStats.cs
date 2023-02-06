using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int money = 0;
    public int targetMoney = 0;

    public int scorePerTick = 1;
    public float tickInterval = 0.01f;

    [Space]

    public float interactRange;

    public Vegetable activeVegetable;

    private void Start()
    {
        targetMoney = money;
        StartCoroutine(Ticker());
    }

    public void AddMoney(int score)
    {
        targetMoney += score;
    }

    public void RemoveMoney(int score)
    {
        targetMoney -= score;
    }

    public IEnumerator Ticker()
    {
        while(true)
         {
            if (money < targetMoney)
            {
                money += scorePerTick;
                if (money > targetMoney)
                {
                    money = targetMoney;
                }
            } else if (money > targetMoney)
            {
                money -= scorePerTick;
                if (money < targetMoney)
                {
                    money = targetMoney;
                }
            }

            yield return new WaitForSeconds(tickInterval);
        }
    }

    private void Update()
    {
        activeVegetable = InventoryManager.instance.GetSelectedVegetable(false);
    }
}
