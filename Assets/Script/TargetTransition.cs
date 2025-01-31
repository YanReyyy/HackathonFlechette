using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetTransition : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text scoreText;
    public TMP_Text timeText;
    private float timeRemaining;

    public float totalTime = 30f;
    public static float score = 0f;
    public static float time = 0f;

    void Start()
    {
        scoreText.text = "Score: " + score;
        timeRemaining = totalTime;

    }

    // Update is called once per frame
    void Update()
    {
        
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
                                
        }

       
        
        UpdateTimeText();
    }

    void UpdateTimeText()
    {
        
        int seconds = Mathf.CeilToInt(timeRemaining);
        timeText.text = "Time: " + timeRemaining;//seconds.ToString();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dart"))
        {
            Debug.Log(" BOUUUUUUUUUM");
            score++;
            if (scoreText != null)
            {
                scoreText.text = "Score: " + score;
            }
        }
    }

}
