using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLevel_1 : MonoBehaviour
{
    // Variable holding the degree of rotation, 90 degrees.
    private int degreeRotation = 90;
    // Referencing the Level Objects in order to rotate.
    public Transform level1Rotate;

    void Start()
    {

    }

    void Update()
    {
        // If player presses Q then the tower rotates.
        if (Input.GetKeyDown("e"))
        {
            // Rotates the Tower Level 1 90 degrees on the Y-axis.
            level1Rotate.Rotate(0, degreeRotation, 0);
        }
    }
}
