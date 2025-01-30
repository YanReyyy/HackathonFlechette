using UnityEngine;
using Debug = UnityEngine.Debug;

public class InteractableObject : MonoBehaviour
{
    public Transform objectToAttach; // Objet � attacher
    private bool isBeingHeld = false;
    public OVRHand ovrHand; // R�f�rence au composant OVRHand

    private Vector3 offset = new(-0.04f, 0.1f, 0.08f);
    private Vector3 rotOffsetAngles = new(-47, -172, 0);

    private void Start()
    {

    }
    private void Update()
    {
        Debug.Log(isBeingHeld);

        if (isBeingHeld)
        {
            if (!ovrHand.GetFingerIsPinching(OVRHand.HandFinger.Index))
            {
                // Rel�che l'objet si le pincement est rel�ch�
                ReleaseObject();
            }
            else
            {
                // Suivre la main pendant qu'elle est tenue
                FollowHand();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning("Here");

        // V�rifie si la main entre en contact avec l'objet
        if (other.CompareTag("Hand"))
        {
            Debug.Log("contact");

            if (ovrHand.GetFingerIsPinching(OVRHand.HandFinger.Index) && !isBeingHeld)
            {
                GrabObject();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Hand") && ovrHand.GetFingerIsPinching(OVRHand.HandFinger.Index) && !isBeingHeld)
        {
            GrabObject();
        }
    }

    private void GrabObject()
    {
        isBeingHeld = true;
        transform.SetParent(objectToAttach); // Attacher directement � la main
        transform.localPosition = new Vector3(0, 0, 0.1f);
        transform.localRotation = Quaternion.Euler(90, 0, 0);
    }

    private void ReleaseObject()
    {

        isBeingHeld = false;
        transform.SetParent(null); // Rel�cher l'objet
        Debug.Log("im launching the dart");

        GetComponent<DartLaunch>().FireDart();

    }

    private void FollowHand()
    {

        // Suivre la position de l'objet attach� avec un d�calage
        transform.position = objectToAttach.position + offset;

        // Appliquer une rotation invers�e
        transform.rotation = objectToAttach.rotation * Quaternion.Euler(rotOffsetAngles);
    }
}
