using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
//using System.Numerics;

public class TargetPointSystem : MonoBehaviour
{
    public TMP_Text scoreText;
    private float totalScore = 0f;
    private HashSet<int> dartIDs = new HashSet<int>();

    void Start()
    {
        scoreText.text = "Score: " + totalScore;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Detected with: " + collision.gameObject.name);
        //Debug.Log("Firstcollision: " + firstcollision);

        DartCollision dart = collision.gameObject.GetComponent<DartCollision>();

        if (dartIDs.Contains(dart.dartID))
        {
            Debug.LogWarning(" " + dart.dartID + " has been counted before");
            return;
        }
        dartIDs.Add(dart.dartID);


        if (collision.gameObject.CompareTag("Dart"))// && firstcollision
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
        Vector3 centerPoint = transform.position;
        centerPoint.x += 2.29f;
        centerPoint.y -= 0.16f;
        centerPoint.z += 0.13f;
        float distance = Vector3.Distance(hitPoint, centerPoint);
        Debug.Log("Center Point" + centerPoint);
        Debug.Log("Distance" + distance);

        // transform.position is the center, r1 = 0.1, r2 = 0.2, r3 = 0.5, r4 = 1
        if (distance < 0.1f)
            return 5f; // r1
        else if (distance < 1.5f)
            return 3f; // r2
        else if (distance < 2f)
            return 1f; // r3
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
