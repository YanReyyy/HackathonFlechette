using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mediumScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject endGame;
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        // V�rifie si la main entre en contact avec l'objet
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
        // ����ȫ���Ѷ�

        GameSettings.SetDifficulty(level);

        endGame.SetActive(true);
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}

