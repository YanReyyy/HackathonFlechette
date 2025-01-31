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
        // �� GameSettings ��ȡ
        moveSpeed = GameSettings.targetMoveSpeed;
        moveInterval = GameSettings.targetSwitchInterval;

        // ����Ŀ��
        ChooseNewTarget();
        InvokeRepeating(nameof(ChooseNewTarget), moveInterval, moveInterval);
    }

    void Update()
    {
        // ƽ���ƶ�
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );
    }

    void ChooseNewTarget()
    {
        // ���Լ�������㷨...
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(0f, 1.5f);
        float z = transform.position.z;
        targetPosition = new Vector3(x, y, z);
    }
}
