using System.Collections;
using System.Collections.Generic;
// DifficultySelectController.cs
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DifficultySelectController : MonoBehaviour
{
    [Header("UI References")]
    public GameObject easyButtonCollider;   // GameObject with a collider for easy button
    public GameObject mediumButtonCollider; // GameObject with a collider for medium button
    public GameObject hardButtonCollider;   // GameObject with a collider for hard button

    void Start()
    {
        // 绑定点击事件
        easyButtonCollider.GetComponent<Collider>().isTrigger = true;
        mediumButtonCollider.GetComponent<Collider>().isTrigger = true;
        hardButtonCollider.GetComponent<Collider>().isTrigger = true;
    }

void OnTriggerEnter(Collider other)
{
        Debug.Log("COLLISION");
    // You can define the object tag or check for a specific player object
    if (other.CompareTag("Hand")) // Make sure the player or hand is the one triggering
    {
        if (other.gameObject == easyButtonCollider)
        {
                Debug.Log("EASY");
                OnChooseDifficulty(1);
        }
        else if (other.gameObject == mediumButtonCollider)
        {
                Debug.Log("NORMAL");
                OnChooseDifficulty(2);
        }
        else if (other.gameObject == hardButtonCollider)
        {
                Debug.Log("HARD");
                OnChooseDifficulty(3);
        }
    }
}


void OnChooseDifficulty(int level)
    {
        // 设置全局难度
        
        GameSettings.SetDifficulty(level);

        // 切换到真正的游戏内容场景
        SceneManager.LoadScene("GameScene");
    }
}
