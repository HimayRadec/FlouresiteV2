using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    float currentScore = 0;

    private void Start()
    {
        currentScore = 0;
    }

    public void AddScore(float amount)
    {
        currentScore += amount;
    }
}
