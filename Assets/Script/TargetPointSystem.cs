using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TargetPointSystem : MonoBehaviour
{
    public TMP_Text scoreText;
    private int totalScore = 0;

    private void Start()
    {
        scoreText.text = "Score: " + totalScore;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Detected with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Dart"))
        {
            Debug.Log("Dart Hit the Board!");
            Vector3 hitPoint = collision.contacts[0].point;
            int score = CalculateScore(hitPoint);

            totalScore += score;
            UpdateScoreUI();
        }
    }

    private int CalculateScore(Vector3 hitPoint)
    {
        float distance = Vector3.Distance(hitPoint, transform.position);

        // transform.position is the center, r1 = 0.1, r2 = 0.2, r3 = 0.5, r4 = 1
        if (distance < 0.1f)
            return 5; // r1
        else if (distance < 0.2f)
            return 3; // r2
        else if (distance < 0.5f)
            return 2; // r3
        else if (distance < 1f)
            return 1; // r4
        else
            return 0; // outside
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + totalScore;
        }
    }
}
