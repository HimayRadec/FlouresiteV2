using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Door : Interactable
{
    [Header("References")]
    private GameObject door;
    private PlayerSettings playerStats;
    private AudioSource doorBoughtSound;

    [Header("Door Settings")]
    private int doorCost;

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
        if (playerStats.points >= doorCost)
        {
            Destroy(gameObject);
            doorBoughtSound.Play();
            playerStats.points =- doorCost;
        }
    }
}
