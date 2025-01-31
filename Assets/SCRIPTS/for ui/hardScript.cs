using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hardScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        // V閞ifie si la main entre en contact avec l'objet
        if (other.CompareTag("Hand"))
        {
            Debug.Log("medium selected");
            OnChooseDifficulty(2);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }

    void OnChooseDifficulty(int level)
    {
        // 设置全局难度

        GameSettings.SetDifficulty(level);

        // 切换到真正的游戏内容场景
        SceneManager.LoadScene("GameScene");
    }
}

