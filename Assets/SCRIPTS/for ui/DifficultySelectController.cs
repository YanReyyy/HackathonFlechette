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
        // �󶨵���¼�
        easyButton.onClick.AddListener(() => OnChooseDifficulty(1));
        mediumButton.onClick.AddListener(() => OnChooseDifficulty(2));
        hardButton.onClick.AddListener(() => OnChooseDifficulty(3));
            
    }

    void OnChooseDifficulty(int level)
    {
        // ����ȫ���Ѷ�
        
        GameSettings.SetDifficulty(level);

        // �л�����������Ϸ���ݳ���
        SceneManager.LoadScene("GameScene");
    }
}
