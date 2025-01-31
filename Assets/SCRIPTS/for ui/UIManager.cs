using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Panels (引用3个面板)")]
    public GameObject panelGameStart;        // 拖拽 Panel_GameStart
    public GameObject panelDifficultySelect; // 拖拽 Panel_DifficultySelect
    public GameObject panelGameContent;      // 拖拽 Panel_GameContent

    [Header("Buttons (引用4个按钮)")]
    public Button startButton;   // 拖拽 StartButton
    public Button easyButton;    // 拖拽 EasyButton
    public Button normalButton;  // 拖拽 NormalButton
    public Button hardButton;    // 拖拽 HardButton

    void Start()
    {
        // 初始只显示 GameStart 面板
        panelGameStart.SetActive(true);
        panelDifficultySelect.SetActive(false);
        panelGameContent.SetActive(false);

        // 给 “开始游戏” 按钮添加监听
        startButton.onClick.AddListener(OnClickGameStart);

        // 绑定难度按钮
        easyButton.onClick.AddListener(() => OnChooseDifficulty(1));
        normalButton.onClick.AddListener(() => OnChooseDifficulty(2));
        hardButton.onClick.AddListener(() => OnChooseDifficulty(3));
    }

    void OnClickGameStart()
    {
        // 隐藏开始游戏面板，显示难度选择面板
        panelGameStart.SetActive(false);
        panelDifficultySelect.SetActive(true);
    }

    void OnChooseDifficulty(int level)
    {
        // 如果需要难度参数，就在这里设置
        GameSettings.SetDifficulty(level);

        // 隐藏难度选择面板，显示游戏内容面板
        panelDifficultySelect.SetActive(false);
        panelGameContent.SetActive(true);

        // 这里也可以触发其他初始化, 比如让靶子脚本开始运动
    }
}
