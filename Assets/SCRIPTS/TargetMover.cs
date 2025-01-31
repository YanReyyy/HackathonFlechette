using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MonoBehaviour
{
    private float moveSpeed;
    private float moveInterval;
    private Vector3 targetPosition;

    void Start()
    {
        // 从 GameSettings 读取
        moveSpeed = GameSettings.targetMoveSpeed;
        moveInterval = GameSettings.targetSwitchInterval;

        // 初次目标
        ChooseNewTarget();
        InvokeRepeating(nameof(ChooseNewTarget), moveInterval, moveInterval);
    }

    void Update()
    {
        // 平滑移动
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );
    }

    void ChooseNewTarget()
    {
        // 你自己的随机算法...
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(0f, 1.5f);
        float z = transform.position.z;
        targetPosition = new Vector3(x, y, z);
    }
}
