using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "ScriptableObject/PlayerSO")]
public class PlayerSO : ScriptableObject
{
    // player data
    public int xp = 0;
    public int level = 0;
    public int skillPoints = 0;

    public void AddXP(int amount)
    {
        xp += amount;

        if (xp / 10 > 1)
        {
            // get new level
            int newLevel = (int)(xp / 10);

            // add skill points for gained levels
            skillPoints += newLevel - level;
            level = newLevel;
        }
    }

}
