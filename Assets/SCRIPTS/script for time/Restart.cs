using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    [Header("UI References")]
    public Button restartButton;
    public Button quitButton;

    void Start()
    {
        // 绑定按钮事件
        if (restartButton != null)
            restartButton.onClick.AddListener(RestartGame);

        if (quitButton != null)
            quitButton.onClick.AddListener(QuitGame);
    }

   
    public void RestartGame()
    {
         SceneManager.LoadScene(1);
    }

   
    public void QuitGame()
    {
        Debug.Log("Quit Game!");
        Application.Quit();

        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
