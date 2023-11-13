using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [SerializeField] private PlayerSO player;
    [SerializeField] private TextMeshProUGUI pointText;

    private void Start()
    {
        pointText.text = player.skillPoints.ToString();
    }

}
