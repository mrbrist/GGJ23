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
    public TextMeshProUGUI constGemTxt;

    public PlayerStats playerMoney;
    public int money;

    //private int seedCost = 30;

    public GameObject FarmUpgradeButton;
    private int farmUpgradeCost = 70;

    public GameObject ShopUpgradeButton;
    private int ShopUpgradeCost = 50;

    public GameObject farmArea2;

    public Button[] buyButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        money = playerMoney.money;

        gemTxt.text = money.ToString();
        constGemTxt.text = money.ToString();

        Buttons();
    }

    public void PurchaseSeedOne(int id)
    {
        if(playerMoney.money >= veg[id].seedCost)
        {
            playerMoney.money -= veg[id].seedCost;
            Debug.Log(veg[id].seedCost);

            FMODUnity.RuntimeManager.PlayOneShot("event:/Actions/buySeeds");
        }
    }

    public void BtnInteractable(int id)
    {
        if (playerMoney.money < veg[id].seedCost)
        {
            buyButton[id].interactable = false;
        }
        else
        {
            buyButton[id].interactable = true;
        }
    }

    public void Buttons()
    {
        // set buttons uninteractable when player doesnt have enough money
        if (playerMoney.money < veg[0].seedCost)
        {
            buyButton[0].interactable = false;
        }
        else
        {
            buyButton[0].interactable = true;
        }

        if (playerMoney.money < veg[1].seedCost)
        {
            buyButton[1].interactable = false;
        }
        else
        {
            buyButton[1].interactable = true;
        }

        if (playerMoney.money < veg[2].seedCost)
        {
            buyButton[2].interactable = false;
        }
        else
        {
            buyButton[2].interactable = true;
        }

        if (playerMoney.money < veg[3].seedCost)
        {
            buyButton[3].interactable = false;
        }
        else
        {
            buyButton[3].interactable = true;
        }
    }

    public void PurchaseFarmUpgrade()
    {
        if(playerMoney.money >= farmUpgradeCost)
        {
            playerMoney.money -= farmUpgradeCost;
            FarmUpgradeButton.GetComponent<Button>().interactable = false;

            farmArea2.SetActive(false);

            FMODUnity.RuntimeManager.PlayOneShot("event:/Actions/buyUpgrades");
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
