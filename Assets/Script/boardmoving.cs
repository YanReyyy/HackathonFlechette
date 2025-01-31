using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BoardMoving : MonoBehaviour
{
    public Transform wall;  // Reference to the wall
    /*public float moveInterval = 2f;
    public float moveSpeed = 2f;*/
    public float moveSpeed = GameSettings.targetMoveSpeed;
    public float moveInterval = GameSettings.targetSwitchInterval;


    private Vector3 targetPosition;
    private float timer;
    private void Start()
    {
        // Set initial position
        ChooseNewTarget();
    }

    private void Update()
    {
        // Move towards target
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        timer += Time.deltaTime;
        if (timer >= moveInterval)
        {
            ChooseNewTarget();
            timer = 0f;
        }
    }

    void ChooseNewTarget()
    {
        float halfWidth = 3.2f / 2f;
        float halfHeight = 2.8f / 2f;
        float randomX = Random.Range(-halfWidth, +halfWidth);
        float randomY = Random.Range(-halfHeight, halfHeight);
        float fixedZ = wall.position.z + 0.05f;
        Vector3 arrive = new Vector3(wall.position.x, wall.position.y, fixedZ) + wall.transform.right * randomX + wall.transform.up * randomY;
        targetPosition = arrive;
        transform.forward = wall.forward;
    }
}