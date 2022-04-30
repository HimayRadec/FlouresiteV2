using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    /// <summary>
    /// This Script is for keeping track and updating the round systems. A Wave
    /// system. After a certian amount of enemies have been killed; increment the
    /// ++Round & ++Enemy(amount to spawn).
    /// 
    /// Probably start off with 4 or 8 enemies at first and add++ 2 or 4 for each
    /// round after. There probably should be cap for the amount we should spawn.
    /// Cap at 24. Going to experiment on that later to see performance MAX. 
    /// 
    /// (Each Player number double the enemies, 1 player 24 zombies, 2 player 48 Z, etc.)
    /// 
    /// Enemies should already be in the levels instead of just creating objects
    /// on the fly for performance. They could be somewhere off the map just idle
    /// and when 'spawned' they really are just teleported to their starting
    /// positions.
    /// 
    /// Also the script should be public and able to interact with other scripts;
    /// grabbing there information for updates on tracking progress.
    /// </summary>

    /* Round Counter
     * Round Tracker
     * 
     * Enemies Killed
     * Enemiees Left
     * 
     * Increments for Both
     */

    public int currentRound;
    public int nextRound = 1;

    public int currentEnemies;
    public int enemiesLeft;

    void Start()
    {
        // Grab the info
    }


    void Update()
    {
        // Check how many enemies are left to be killed...
        // if complete next round. Add round and enemy count.
    }

    // Add functions to grab info from other scipts.
}

// This might only work with the only scripts I had but I'll test that.
