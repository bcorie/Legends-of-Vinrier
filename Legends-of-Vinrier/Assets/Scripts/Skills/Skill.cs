using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Part of the Skill Tree.
/// Contains all data needed for each skill.
/// </summary>
[CreateAssetMenu(fileName = "Skill", menuName = "ScriptableObject/SkillSO")]
public class Skill : ScriptableObject
{
    public bool isUnlocked = false;

    public string title;

    // base (universal), melee, magic
    public string type;

    // description
    public string desc;

    // stat modifications (format: "attack+1" or "maxHP-2")
    public List<string> modifications = new List<string>();

    // cost to unlock or requirement to meet
    public int cost;


}
