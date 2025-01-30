using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TargetPointSystem : MonoBehaviour
{
    public TMP_Text scoreText;
    private float totalScore = 0f;

    void Start()
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
            Debug.Log("Hit Point" + hitPoint);
            float score = CalculateScore(hitPoint);

            totalScore += score;
            Debug.Log("Total Score" + totalScore);
            UpdateScoreUI();
        }
    }

    private float CalculateScore(Vector3 hitPoint)
    {
        Debug.Log("Transform Point" + transform.position);
        Vector3 centerPoint=transform.position;
        //centerPoint.x += 2.172f;
        //centerPoint.y += -0.25f;
        //centerPoint.z = 0f;
        float distance = Vector3.Distance(hitPoint, centerPoint);
        Debug.Log("Center Point" + centerPoint);
        Debug.Log("Distance" + distance);

        // transform.position is the center, r1 = 0.1, r2 = 0.2, r3 = 0.5, r4 = 1
        if (distance < 0.1f)
            return 2.5f; // r1
        else if (distance < 1.5f)
            return 1.5f; // r2
        else if (distance < 2f)
            return 0.5f; // r3
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
