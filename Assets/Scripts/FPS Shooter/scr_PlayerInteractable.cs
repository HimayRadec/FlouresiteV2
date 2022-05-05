using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class scr_PlayerInteract : MonoBehaviour
{
    [Header("References")]
    public Camera cam;
    public LayerMask mask;
    public scr_PlayerUI playerUI;
    private DefaultInput inputManager;

    [SerializeField]
    private float distance = 3f;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    //Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        //create a ray at the center of the camera, shooting outwards
        
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);

        RaycastHit hitInfo; // variable to store our collision information. 
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);

                if (inputManager.Character.Interact.triggered)
                {
                    interactable.BaseInteract();
                }


            }
        }
    }

    public void Interact()
    {
       
    }
}