using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour
{
    public Vegetable[] veg;
    public InventoryManager InventoryManager;

    public TextMeshProUGUI gemTxt;

    public PlayerStats playerMoney;
    public int money;

    //private int seedCost = 30;

    public GameObject FarmUpgradeButton;
    private int farmUpgradeCost = 70;

    public GameObject ShopUpgradeButton;
    private int ShopUpgradeCost = 50;

    public GameObject farmArea2;

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

    public void PurchaseSeedOne(int id)
    {
        if(playerMoney.money >= veg[id].seedCost)
        {
            playerMoney.money -= veg[id].seedCost;
            Debug.Log(veg[id].seedCost);
        }
    }

    public void test(int id)
    {
        if (playerMoney.money <= veg[id].seedCost)
        {
            
        }
    }

    public void PurchaseFarmUpgrade()
    {
        if(playerMoney.money >= farmUpgradeCost)
        {
            playerMoney.money -= farmUpgradeCost;
            FarmUpgradeButton.GetComponent<Button>().interactable = false;

            farmArea2.SetActive(false);
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
