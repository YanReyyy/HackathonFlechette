using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

//public class TargetMover : MonoBehaviour
//{
//    public Transform wall;  // ��ǽ��
//    public float moveSpeed = 2f; // �˶��ٶ�
//    public float moveInterval = 2f; // ��û�һ��Ŀ���

//    private Vector3 targetPosition; // ���ӵ�Ŀ��λ��
//    private Bounds wallBounds; // ǽ�ı߽緶Χ

//  void Start()
//    {
//        ChooseNewTarget();
//        InvokeRepeating("ChooseNewTarget", moveInterval, moveInterval);
//    }

//  void Update()
//    {
//        // �ð���ƽ���ƶ���Ŀ��λ��
        
//        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
//    }

//  void ChooseNewTarget()
//    {
        
       
//        float halfWidth = 3.2f / 2f;
//        float halfHeight = 2.8f / 2f;

//        float randomX = Random.Range(wall.position.x - halfWidth, wall.position.x + halfWidth);
//        float randomY = Random.Range(wall.position.y - halfHeight, wall.position.y + halfHeight);
//        float fixedZ = wall.position.z+0.05f;


//        targetPosition = new Vector3(randomX, randomY, fixedZ);
//    }
//}
