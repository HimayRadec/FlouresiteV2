using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunSystem : MonoBehaviour
{
    // Gun Stats
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    // Booleans
    bool shooting, reloading, readyToShoot;

    // Reference
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    // Graphics
    public GameObject muzzleFlash, bulletHoleGraphic;
    public CameraShake camShake;
    public float camShakeMagnitude, camShakeDuration;
    public TextMeshProUGUI text;


    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update()
    {
        myInput();

        // set text
        text.SetText(bulletsLeft + " / " + magazineSize);
    }


    // input controller
    public void myInput()
    {
        // if the gun isnt a tap fire and the player is pressing down
        // the left mouse button, then shooting is true
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);


        // reloading
        if (Input.GetKey(KeyCode.R) && !reloading && bulletsLeft > magazineSize) Reload();

        // shooting
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }

    }


    // MAIN FUNCTIONS
    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished()", reloadTime);
    }

    private void ReloadFinished()
    {
        reloading = false;
        bulletsLeft = magazineSize;
    }

    private void Shoot()
    {
        readyToShoot = false;

        // shot spread
        // ** Add in a increasing spread when walking and running **
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        // calculate direction with spread
        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);


        // raycast
        if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy))
        {
            // check if bullets hit an enemy
            Debug.Log(rayHit.collider.name);
            if (rayHit.collider.CompareTag("Enemy"))

                // make the enemy take damage
                rayHit.collider.GetComponent<ShootingAi>().TakeDamage(damage);
        }


        // shakes camera after shot
        camShake.Shake(camShakeDuration, camShakeMagnitude);

        // graphics
        Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));
        Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if(bulletsShot > 0 && bulletsLeft > 0)  
        Invoke("Shoot", timeBetweenShots);
        
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }
      
}


