using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkillSceneManager : MonoBehaviour
{
    [SerializeField] private PlayerSO player;
    [SerializeField] private TextMeshProUGUI pointText;

    private void Start()
    {
        pointText.text = "Points to spend: " + player.skillPoints.ToString();
    }

    public void BackButton()
    {
        SceneManager.UnloadSceneAsync("SkillTree");
        SceneManager.LoadSceneAsync("Map 1");
    }
}
