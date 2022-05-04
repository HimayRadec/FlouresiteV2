using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Gradient weaponName;
    public Image fill;
    public Text pointsDisplay;
    public Text maxAmmo;
    public Text currentAmmo;
    public Text roundNumber;
    public Text weaponDisplay;
    public GameObject gun;

    public void Awake()
    {
        gun.GetComponent<WeaponSystem>();
    }
    public void SetMaxHealth(int health)
    {
        
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health) 
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetPoints(int points)
    {
        pointsDisplay.text = points.ToString();
    }

    public void SetAmmo(int currAmmo)
    {
        currentAmmo.text = currAmmo.ToString();
    }

    public void SetMaxAmmo(int ammo)
    {
        maxAmmo.text = ammo.ToString();
    }

    public void SetRound(int round)
    {
        roundNumber.text = round.ToString(); 
    }

    public void SetWeapon(string weapon)
    {
        weaponDisplay.text = weapon;
    }

}


// NOTES FOR IMPLEMENTING THIS CODE IN OTHER SCRIPTS
/* First copy the whole canvas with the health bar into the game scene, the player script should also be here
 * To call and update the health bar from another script, first create a reference in the player script to the health bar by adding "public HealthBar healthbar;"
 * drag the health bar in the hierarchy into the referenced healthBar of the player script in the inspector
 * then in the start function, to initialize the health at max, do "healthBar.SetMaxHealth(maxPlayerHealth);"
 * and then in the function that controls the player damage, do "healthBar.SetHealth(currentPlayerHealth);"
 * oh, and the variables for maxHealth and currentHealth can be changed to whatever you already have, just adjust the variables in this script to reflect that
 * 
 * you can change the variables to reference the global variables, I just had to declare them here to resolve compiler issues
 * 
 * because all the ui is here in this scene, you can either copy it all into another scene (not too difficult), or keep them independent and then
 * run both any game scenes and the ui scene at the same time. just make sure for the ui scene, you implement "DontDestroyOnLoad(this.gameObject)" 
 * so the scene isn't destroyed upon loading a new scene
 */