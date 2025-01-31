using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;           

public class GameTimer : MonoBehaviour
{

    

    [Header("Timer Settings")]
    public float totalTime = 30f;            // ��ʱ�� 30 ��
    private float timeRemaining;

    [Header("UI References")]
    
    public TMP_Text timeText;             // ����� TextMeshPro�������TMP_Text
    public TMP_Text scoreText;                   // ��Ϸ��ʵʱ�÷�(��ѡ)
    public GameObject gameOverPanel;         // ��Ϸ����UI���
    public TMP_Text gameOverScoreText;           // ��Ϸ���������ĵ÷���ʾ

    [Header("Audio")]
    public AudioSource audioSource;  // ����ʱ���ŵ���ƵԴ
    public AudioClip gameOverClip;   // ����ʱ���ŵ������ļ�
 
    

    [Header("Audio")]
    public AudioSource audioSource2;  // ����ʱ���ŵ���ƵԴ
    public AudioClip gameOverClip2;   // ����ʱ���ŵ������ļ�

    // ��ķ����߼�(ʾ��)
    private int currentScore = 0;

    private bool isGameOver = false;


   
    void Start()
    {
        timeRemaining = totalTime;
        gameOverPanel.SetActive(false);      // ��ʼʱ������Ϸ�������
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
        if (isGameOver) return;             // �����Ϸ�Ѿ����������ٸ��µ���ʱ

        // ÿ֡����ʱ��
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            EndGame();                      // ʱ�䵽��������Ϸ
        }

        // ���µ���ʱ�ı�
        UpdateTimeText();
    }

    /// <summary>
    /// ���� TimeText ��ʾ
    /// </summary>
    void UpdateTimeText()
    {
        // �Ѹ�����ת���������� xx:xx ��ʽ����
        // ����ʾ����ʾ������
        int seconds = Mathf.CeilToInt(timeRemaining);
        timeText.text = "Time: " + seconds.ToString();
    }

    /// <summary>
    /// �ṩ�������ű��ӷ�
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
    /// ʱ�䵽��������������Ϸ����
    /// </summary>
    void EndGame()
    {
        isGameOver = true;

        // ������Ϸ�������
        gameOverPanel.SetActive(true);

        // ��ʾ���յ÷�
        if (gameOverScoreText != null)
        {
            gameOverScoreText.text = "Final Score: " + currentScore.ToString();
        }

        // ��Ҳ���Խ���һЩ�����������÷��ڲ������䣬����ֹͣ�ƶ�����
        if (audioSource != null && gameOverClip != null)
        {
            audioSource.clip = gameOverClip;
            audioSource.Play();
        }
    }
}

