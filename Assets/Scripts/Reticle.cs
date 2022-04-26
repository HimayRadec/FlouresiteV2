using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reticle : MonoBehaviour
{
    /// <summary>
    /// I found if you set
    /// 
    /// Resting Size = 100
    /// Max Size = 250
    /// Speed = 6 
    /// 
    /// It smoother with these presets.
    /// </summary>


    // Referencing the Reticle gameobject in the Canvas.
    private RectTransform reticle;

    // Variables for the size of the Recticles when the player is moving or idle.
    public float restingSize; // Idle
    public float maxSize; // Moving
    public float speed; // How quickly it moves in/out
    private float currentSize;

    private void Start()
    {
        // Assigning the variable
        reticle = GetComponent<RectTransform>();
    }

    private void Update()
    {
        // Checking is the player is moving in any way execute if()Statement
        if (isMoving)
        {
            // Moving
            currentSize = Mathf.Lerp(currentSize, maxSize, Time.deltaTime * speed);
        }
        else
        {
            // Not moving
            currentSize = Mathf.Lerp(currentSize, restingSize, Time.deltaTime * speed);
        }
        reticle.sizeDelta = new Vector2(currentSize, currentSize);

    }

    bool isMoving
    {
        // Checking if the inputs of player movement are true or not.
        get {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                return true;
            else
                return false;
        }
    }


}
