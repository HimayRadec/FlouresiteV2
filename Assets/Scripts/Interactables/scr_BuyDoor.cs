using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_BuyDoor : Interactable
{
    public PlayerSettings playerStats;
    public scr_CharacterController characterController;

    AudioSource purchaseSuccessful;
    public int cost;

    // Start is called before the first frame update
    void Start()
    {
        purchaseSuccessful = GetComponent<AudioSource>();
    }

    protected override void Interact()
    {

        if (playerStats.points >= cost)
        {

            playerStats.points -= cost;
            purchaseSuccessful.Play();
            Destroy(gameObject, 1);
        }
    }
}
