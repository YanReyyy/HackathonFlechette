using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dartflytest : MonoBehaviour
{
    public Rigidbody rb;
    public float throwSpeed = 20f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.velocity = transform.up * throwSpeed;
    }
}
