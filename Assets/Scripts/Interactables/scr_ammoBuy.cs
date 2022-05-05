using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ammoBuy : Interactable
{
    public PlayerSettings playerStats;
    public scr_CharacterController weaponInHand;

    private int ammoCost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact()
    {
        if (playerStats.points >= ammoCost)
        {
            weaponInHand.weaponInHand.totalAmmo += weaponInHand.weaponInHand.magazineSize;
        }
    }
}
