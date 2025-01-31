using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class easyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject endGame;
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        // V閞ifie si la main entre en contact avec l'objet
        if (other.CompareTag("Hand"))
        {
            Debug.Log("easy selected");
            OnChooseDifficulty(1);
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
        gameObject.transform.parent.gameObject.SetActive(false);
        endGame.SetActive(true);
    
    }
}

