using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public int energyLevel;
    public int maxEnergy;

    // Drain Function

    public void Drain(int drainAmount, Energy target)
    {
        int minDrainAmount;
        int targetDrainAmount = drainAmount;
        int thisDrainAmount = drainAmount;

        // Check how much to drain/gain
        if (target.energyLevel - drainAmount <= 0)
        {
            targetDrainAmount = target.energyLevel;
        }

        if (this.energyLevel + drainAmount >= this.maxEnergy)
        {
            thisDrainAmount = this.maxEnergy - this.energyLevel;
        }

        // Find minimum drain amount
        minDrainAmount = Mathf.Min(targetDrainAmount, thisDrainAmount);

        // Set new energy levels
        target.energyLevel = Mathf.Max(0, target.energyLevel - minDrainAmount);
        this.energyLevel = Mathf.Min(this.maxEnergy, this.energyLevel + minDrainAmount);

        //Destroy if energy is 0
        if (target.energyLevel <= 0)
        {
            Destroy(target);
        }
    } 
}
