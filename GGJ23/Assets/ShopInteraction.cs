using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInteraction : MonoBehaviour
{
    public GameObject ShopUI;
    public GameObject Player;

    private bool MenuActive = false;
    private bool inCollision = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inCollision)
        {
            if (Input.GetKeyDown(KeyCode.E) && !MenuActive)
            {
                ShopUI.SetActive(true);
                Player.GetComponent<CharacterController>().speed = 0;
            }
            else if (Input.GetKeyDown(KeyCode.E) && MenuActive)
            {
                ShopUI.SetActive(false);
                Player.GetComponent<CharacterController>().speed = 10;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        inCollision = true;
    }

    void OnTriggerExit(Collider other)
    {
        inCollision = false;
    }
}
