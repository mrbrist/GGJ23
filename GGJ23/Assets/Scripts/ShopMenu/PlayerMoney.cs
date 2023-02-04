using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMoney : MonoBehaviour
{
    public TextMeshProUGUI gemTxt;

    public PlayerStats playerMoney;

    private int money;

    private int seedCost = 27;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        money = playerMoney.money;

        gemTxt.text = money.ToString();
    }

    public void PurchaseSeedOne()
    {
        if(playerMoney.money >= seedCost)
        {
            playerMoney.money -= seedCost;
        }
    }
}
