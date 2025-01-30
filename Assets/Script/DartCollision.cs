using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartCollision : MonoBehaviour
{
    private bool isStuck = false; // stuck on the board or not

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.CompareTag("Dartboard") || collision.gameObject.CompareTag("Environment")) && !isStuck)
        {
            isStuck = true; // stuck

            // stop the dart
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;

            // let it stick
            Vector3 hitPoint = collision.contacts[0].point;
            rb.MovePosition(hitPoint);
            //transform.position = hitPoint;
            transform.SetParent(collision.transform);
        }
    }
}
