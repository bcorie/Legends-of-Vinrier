using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class SkillHandler : MonoBehaviour
{
    // find scriptable object
    [SerializeField] private Skill skill;
    [SerializeField] private PlayerSO player;

    // sibling components
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI modText;

    // get parts of modifier
    // (will be easier to apply if broken up)
    private string modName, modType;
    private int modValue;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = skill.title;
        ConvertMod(skill.modifier);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ConvertMod(string mod)
    {
        for (int i = 0; i < mod.Length; i++)
        {
            if (mod[i] == '-')
            {
                modType = "-";
                modName = mod.Substring(0, i);
                modValue = Int32.Parse(mod.Substring(i + 1));
            }

            if (mod[i] == '+')
            {
                modType = "+";
                modName = mod.Substring(0, i);
                modValue = Int32.Parse(mod.Substring(i + 1));
            }
        }

        switch (modName)
        {
            case "attack":
                modText.text = "Attack +" + modValue;
                break;

            case "maxHP":
                modText.text = "Max HP + " + modValue;
                break;

            default:
                modText.text = "Error.";
                break;
        }
    }

    private void AttemptPurchase()
    {
        if (player.skillPoints < skill.cost)
        {
            skill.desc = "Not enough points.";
        }
        else
        {
            skill.isUnlocked = true;

            // TODO: change appearance
            
            Debug.Log(skill.title + " has been unlocked!");
        }
    }
}
