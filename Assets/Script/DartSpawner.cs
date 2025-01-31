using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartSpawner : MonoBehaviour
{
    public GameObject dartPrefab;
    public int dartCount = 15;
    public float spacing = 0.2f;
    public float rightOffset = 0.5f;
    public float heightOffset = -0.2f;
    private Camera arCamera;

    void Start()
    {
        arCamera = Camera.main;
        StartCoroutine(SpawnDarts());
    }

    IEnumerator SpawnDarts()
    {
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < dartCount; i++)
        {
            Vector3 playerPosition = arCamera.transform.position;
            Vector3 rightDirection = arCamera.transform.right;
            Vector3 forwardDirection = arCamera.transform.forward;

            // playerposition -> worldposition
            Vector3 dartPosition = playerPosition + rightDirection * rightOffset + Vector3.up * heightOffset + forwardDirection * (i * spacing);

            // Create
            GameObject newDart = Instantiate(dartPrefab, dartPosition, Quaternion.identity);
            newDart.transform.rotation = Quaternion.Euler(90, 0, 0);
            newDart.transform.SetParent(null, true); // Don't move with the camera
        }
    }
}
