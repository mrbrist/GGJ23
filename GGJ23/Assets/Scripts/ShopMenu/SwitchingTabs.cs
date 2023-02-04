using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingTabs : MonoBehaviour
{
    public GameObject BuyActive;
    public GameObject SellActive;

    public GameObject BuyActiveTABS;
    public GameObject SellActiveTABS;


    // Start is called before the first frame update
    void Start()
    {
        SellActive.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuySelected()
    {
        SellActive.SetActive(false);
        BuyActive.SetActive(true);

        SellActiveTABS.SetActive(false);
        BuyActiveTABS.SetActive(true);
    }

    public void SellSelected()
    {
        SellActive.SetActive(true);
        BuyActive.SetActive(false);

        SellActiveTABS.SetActive(true);
        BuyActiveTABS.SetActive(false);

    }
}
