using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

//public class TargetMover : MonoBehaviour
//{
//    public Transform wall;  // 绑定墙面
//    public float moveSpeed = 2f; // 运动速度
//    public float moveInterval = 2f; // 多久换一个目标点

//    private Vector3 targetPosition; // 靶子的目标位置
//    private Bounds wallBounds; // 墙的边界范围

//  void Start()
//    {
//        ChooseNewTarget();
//        InvokeRepeating("ChooseNewTarget", moveInterval, moveInterval);
//    }

//  void Update()
//    {
//        // 让靶子平滑移动到目标位置
        
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
