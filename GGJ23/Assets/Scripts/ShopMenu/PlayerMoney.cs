using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour
{
    public TextMeshProUGUI gemTxt;

    public PlayerStats playerMoney;
    private int money;

    private int seedCost = 30;

    public GameObject FarmUpgradeButton;
    private int farmUpgradeCost = 70;

    public GameObject ShopUpgradeButton;
    private int ShopUpgradeCost = 50;

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

    public void PurchaseFarmUpgrade()
    {
        if(playerMoney.money >= farmUpgradeCost)
        {
            playerMoney.money -= farmUpgradeCost;
            FarmUpgradeButton.GetComponent<Button>().interactable = false;
        }
    }

    public void PurchaseShopUpgrade()
    {
        if (playerMoney.money >= ShopUpgradeCost)
        {
            playerMoney.money -= ShopUpgradeCost;
            ShopUpgradeButton.GetComponent<Button>().interactable = false;
        }
    }
}
