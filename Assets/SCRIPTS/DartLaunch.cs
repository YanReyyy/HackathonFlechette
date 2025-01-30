using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartLaunch : MonoBehaviour
{
    public GameObject dart;
    public float launchForce = 10f;
    private bool isLaunched = false;
    private Vector3 launchDir;

    // Start is called before the first frame update
    void Start()
    {
        //waiting for gesture
      
    }

    // Update is called once per frame
    void Update()
    {
        // Si la fléchette a été tirée, mettre à jour la position en fonction de la direction du tir.
        if (isLaunched)
        {
            Debug.Log("islaunched");
        }
    }

    // Called when pinch released
    public void FireDart()
    {
        Debug.Log("FireDart method called.");
        Rigidbody rb = dart.GetComponent<Rigidbody>();
        if (dart != null && !isLaunched)
        {
            //launchDir = dart.GetComponent<speed>().GetLaunchDirection();
            launchDir = new Vector3(0.0f, -2.0f, -0.5f);
            if (rb != null)
            {
                //rb.velocity = launchDir * launchForce;
                //rb.velocity = dart.GetComponent<speed>().GetLaunchDirection()*dart.GetComponent<speed>().GetCurrentSpeed();
                rb.velocity = new Vector3(0.0f, -2.0f, -5.0f);
                isLaunched = true;
                Debug.Log("Dart launched with velocity: " + rb.velocity);
            }
        }
    }
}