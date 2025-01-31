using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStartController : MonoBehaviour
{
    [Header("UI References")]
    public Button startButton;  // ÔÚInspectorÀïÍÏ×§ StartButton
    public GameObject diffSelec;
    public Vector3 positionDiff = new(0f, 0f, 0f);
    public GameObject HandParent; 

    void Start()
    {
      
        /*startButton.onClick.AddListener(OnClickStartGame);*/
    }

    private void OnTriggerEnter(Collider other)
    {

        // Vérifie si la main entre en contact avec l'objet
        if (other.CompareTag("Hand"))
        {
            Debug.Log("touch game start");
            TargetTransition.score = 0;
            OnClickStartGame();
        }
    }

    void OnClickStartGame()
    {
        // DifficultySelectScene
        /*SceneManager.LoadScene("DifficultySelectScene"); Previous Jihen method */
        // Instantiate(diffSelec, positionDiff, Quaternion.identity) ;
        diffSelec.SetActive(true);
        
        gameObject.SetActive(false);
        
    }
}
