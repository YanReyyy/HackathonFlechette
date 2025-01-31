using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStartController : MonoBehaviour
{
    [Header("UI References")]
    public Button startButton;  // ÔÚInspectorÀïÍÏ×§ StartButton

    void Start()
    {
      
        startButton.onClick.AddListener(OnClickStartGame);
    }

    void OnClickStartGame()
    {
        // ÇÐ»»µ½ DifficultySelectScene
        SceneManager.LoadScene("DifficultySelectScene");
    }
}
