using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ammoBuy : Interactable
{
    public PlayerSettings playerStats;
    public scr_CharacterController characterController;
    AudioSource purchaseSuccessful;

    public int ammoCost;
    void Start()
    {
        purchaseSuccessful = GetComponent<AudioSource>();
    }


    protected override void Interact()
    {
        Debug.Log("Ammo Bought Attemtped");

        if (playerStats.points >= ammoCost)
        {
            characterController.currentWeapon.totalAmmo += characterController.weaponInHand.magazineSize;
            playerStats.points -= ammoCost;
            purchaseSuccessful.Play();
        }
    }
}
