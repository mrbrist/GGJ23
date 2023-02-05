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
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!MenuActive)
                {
                    MenuActive = true;
                    ShopUI.SetActive(true);
                    Player.GetComponent<CharacterController>().speed = 0;

                    FMODUnity.RuntimeManager.PlayOneShot("event:/Actions/shopDoorOpen");

                } else
                {
                    MenuActive = false;
                    ShopUI.SetActive(false);
                    Player.GetComponent<CharacterController>().speed = 10;

                    FMODUnity.RuntimeManager.PlayOneShot("event:/Actions/shopDoorClose");

                }
                
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inCollision = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inCollision = false;
        }
    }
}
