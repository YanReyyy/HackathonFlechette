using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Panels (����3�����)")]
    public GameObject panelGameStart;        // ��ק Panel_GameStart
    public GameObject panelDifficultySelect; // ��ק Panel_DifficultySelect
    public GameObject panelGameContent;      // ��ק Panel_GameContent

    [Header("Buttons (����4����ť)")]
    public Button startButton;   // ��ק StartButton
    public Button easyButton;    // ��ק EasyButton
    public Button normalButton;  // ��ק NormalButton
    public Button hardButton;    // ��ק HardButton

    void Start()
    {
        // ��ʼֻ��ʾ GameStart ���
        panelGameStart.SetActive(true);
        panelDifficultySelect.SetActive(false);
        panelGameContent.SetActive(false);

        // �� ����ʼ��Ϸ�� ��ť��Ӽ���
        startButton.onClick.AddListener(OnClickGameStart);

        // ���ѶȰ�ť
        easyButton.onClick.AddListener(() => OnChooseDifficulty(1));
        normalButton.onClick.AddListener(() => OnChooseDifficulty(2));
        hardButton.onClick.AddListener(() => OnChooseDifficulty(3));
    }

    void OnClickGameStart()
    {
        // ���ؿ�ʼ��Ϸ��壬��ʾ�Ѷ�ѡ�����
        panelGameStart.SetActive(false);
        panelDifficultySelect.SetActive(true);
    }

    void OnChooseDifficulty(int level)
    {
        // �����Ҫ�ѶȲ�����������������
        GameSettings.SetDifficulty(level);

        // �����Ѷ�ѡ����壬��ʾ��Ϸ�������
        panelDifficultySelect.SetActive(false);
        panelGameContent.SetActive(true);

        // ����Ҳ���Դ���������ʼ��, �����ð��ӽű���ʼ�˶�
    }
}
