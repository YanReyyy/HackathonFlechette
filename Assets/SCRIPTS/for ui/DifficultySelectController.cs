using System.Collections;
using System.Collections.Generic;
// DifficultySelectController.cs
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DifficultySelectController : MonoBehaviour
{
    [Header("UI References")]
    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;

    void Start()
    {
        // 绑定点击事件
        easyButton.onClick.AddListener(() => OnChooseDifficulty(1));
        mediumButton.onClick.AddListener(() => OnChooseDifficulty(2));
        hardButton.onClick.AddListener(() => OnChooseDifficulty(3));
            
    }

    void OnChooseDifficulty(int level)
    {
        // 设置全局难度
        
        GameSettings.SetDifficulty(level);

        // 切换到真正的游戏内容场景
        SceneManager.LoadScene("GameScene");
    }
}
