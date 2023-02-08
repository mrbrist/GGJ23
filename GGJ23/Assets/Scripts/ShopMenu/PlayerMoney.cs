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
    public GameObject farmArea3;

    public GameObject UIFarm1;
    public GameObject UIFarm2;

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
        if(playerMoney.targetMoney >= veg[id].seedCost)
        {
            playerMoney.RemoveMoney(veg[id].seedCost);
            Debug.Log(veg[id].seedCost);

            FMODUnity.RuntimeManager.PlayOneShot("event:/Actions/buySeeds");
        }
    }

    public void BtnInteractable(int id)
    {
        if (playerMoney.targetMoney < veg[id].seedCost)
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
        if (playerMoney.targetMoney < veg[0].seedCost)
        {
            buyButton[0].interactable = false;
        }
        else
        {
            buyButton[0].interactable = true;
        }

        if (playerMoney.targetMoney < veg[1].seedCost)
        {
            buyButton[1].interactable = false;
        }
        else
        {
            buyButton[1].interactable = true;
        }

        if (playerMoney.targetMoney < veg[2].seedCost)
        {
            buyButton[2].interactable = false;
        }
        else
        {
            buyButton[2].interactable = true;
        }

        if (playerMoney.targetMoney < veg[3].seedCost)
        {
            buyButton[3].interactable = false;
        }
        else
        {
            buyButton[3].interactable = true;
        }
    }

    public void PurchaseFarmUpgrade1()
    {
        if(playerMoney.targetMoney >= farmUpgradeCost)
        {
            playerMoney.RemoveMoney(farmUpgradeCost);
            FarmUpgradeButton.GetComponent<Button>().interactable = false;

            farmUpgradeCost = 500;

            farmArea2.SetActive(false);

            UIFarm1.SetActive(false);
            UIFarm2.SetActive(true);


            FMODUnity.RuntimeManager.PlayOneShot("event:/Actions/buyUpgrades");
        }
    }

    public void PurchaseFarmUpgrade2()
    {
        if (playerMoney.targetMoney >= farmUpgradeCost)
        {
            playerMoney.RemoveMoney(farmUpgradeCost);
            FarmUpgradeButton.GetComponent<Button>().interactable = false;

            farmArea3.SetActive(false);

            UIFarm1.SetActive(false);
            UIFarm2.SetActive(false);


            FMODUnity.RuntimeManager.PlayOneShot("event:/Actions/buyUpgrades");
        }
    }

    public void PurchaseShopUpgrade()
    {
        if (playerMoney.targetMoney >= ShopUpgradeCost)
        {
            playerMoney.RemoveMoney(ShopUpgradeCost);
            ShopUpgradeButton.GetComponent<Button>().interactable = false;
        }
    }
}
