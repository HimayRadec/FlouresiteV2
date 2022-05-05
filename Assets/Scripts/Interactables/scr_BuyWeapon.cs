using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_BuyWeapon : Interactable
{
    public PlayerSettings playerStats;
    public scr_CharacterController characterController;
    public GameObject weapon;
    AudioSource purchaseSuccessful;
    public int cost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected override void Interact()
    {

        if (playerStats.points >= cost)
        {

            playerStats.points -= cost;
            purchaseSuccessful.Play();
        }
    }
}
