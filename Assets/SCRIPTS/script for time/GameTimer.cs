using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;           

public class GameTimer : MonoBehaviour
{

    

    [Header("Timer Settings")]
    public float totalTime = 30f;            // 总时长 30 秒
    private float timeRemaining;

    [Header("UI References")]
    
    public TMP_Text timeText;             // 如果用 TextMeshPro，请改用TMP_Text
    public TMP_Text scoreText;                   // 游戏中实时得分(可选)
    public GameObject gameOverPanel;         // 游戏结束UI面板
    public TMP_Text gameOverScoreText;           // 游戏结束面板里的得分显示

    [Header("Audio")]
    public AudioSource audioSource;  // 结束时播放的音频源
    public AudioClip gameOverClip;   // 结束时播放的音乐文件
 
    

    [Header("Audio")]
    public AudioSource audioSource2;  // 结束时播放的音频源
    public AudioClip gameOverClip2;   // 结束时播放的音乐文件

    // 你的分数逻辑(示例)
    private int currentScore = 0;

    private bool isGameOver = false;


   
    void Start()
    {
        timeRemaining = totalTime;
        gameOverPanel.SetActive(false);      // 开始时隐藏游戏结束面板
        PlayBackgroundMusic();
    }

    public void PlayBackgroundMusic()
    {
        if (audioSource2  != null && gameOverClip2 != null)
        {
            audioSource.clip = gameOverClip2;
            audioSource.Play();
        }
    }

    void Update()
    {
        if (isGameOver) return;             // 如果游戏已经结束，不再更新倒计时

        // 每帧减少时间
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            EndGame();                      // 时间到，结束游戏
        }

        // 更新倒计时文本
        UpdateTimeText();
    }

    /// <summary>
    /// 更新 TimeText 显示
    /// </summary>
    void UpdateTimeText()
    {
        // 把浮点数转化成整数或 xx:xx 格式都行
        // 这里示例显示整数秒
        int seconds = Mathf.CeilToInt(timeRemaining);
        timeText.text = "Time: " + seconds.ToString();
    }

    /// <summary>
    /// 提供给其他脚本加分
    /// </summary>
    public void AddScore(int value)
    {
        currentScore += value;
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore.ToString();
        }
    }

    /// <summary>
    /// 时间到或其他条件，游戏结束
    /// </summary>
    void EndGame()
    {
        isGameOver = true;

        // 弹出游戏结束面板
        gameOverPanel.SetActive(true);

        // 显示最终得分
        if (gameOverScoreText != null)
        {
            gameOverScoreText.text = "Final Score: " + currentScore.ToString();
        }

        // 你也可以禁用一些操作，比如让飞镖不能再射，或者停止移动靶子
        if (audioSource != null && gameOverClip != null)
        {
            audioSource.clip = gameOverClip;
            audioSource.Play();
        }
    }
}

