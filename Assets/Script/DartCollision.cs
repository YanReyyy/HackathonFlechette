using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class DartCollision : MonoBehaviour
{
    private bool isStuck = false; // stuck on the board or not
    private Rigidbody rb;
    public int dartID;
    private static int dartIDCounter = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        dartID = dartIDCounter;
        dartIDCounter++;
        Debug.Log("Create the dart" + dartID);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // || collision.gameObject.CompareTag("Environment")) && !isStuck
        if ((collision.gameObject.CompareTag("Dartboard")))
        {
            isStuck = true; // stuck
            Debug.Log("Dart hit board");
            // stop the dart
            rb.isKinematic = false;
            rb.useGravity = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;

            // let it stick
            Vector3 hitPoint = collision.contacts[0].point;
            rb.MovePosition(hitPoint);
            //Vector3 hhhhh = hitPoint;
            //hhhhh.x -= 2.172f;
            //hhhhh.y += -0.25f;
            //hhhhh.z -= 0.5f;
            //transform.position = hitPoint;
            transform.SetParent(collision.transform);

        }
    }
}
