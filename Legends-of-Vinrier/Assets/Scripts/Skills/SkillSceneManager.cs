using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkillSceneManager : MonoBehaviour
{
    [SerializeField] private PlayerSO player;
    [SerializeField] private TextMeshProUGUI pointText;
    [SerializeField] private GameManager gameManager;

    private void Start()
    {
        pointText.text = "Points to spend: " + player.skillPoints.ToString();
    }

    public void BackButton()
    {
        // skill scene will always be loaded with gamemanager's method
        // TODO: dont hard code scenes
        gameManager.SwitchSceneByObjects(SceneManager.GetSceneByPath("Assets/Scenes/SkillTree.unity"), SceneManager.GetSceneByPath("Assets/Scenes/Map 1.unity"));
    }
}
