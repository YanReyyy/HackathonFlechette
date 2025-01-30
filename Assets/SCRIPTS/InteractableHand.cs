using UnityEngine;
using Debug = UnityEngine.Debug;

public class InteractableObject : MonoBehaviour
{
    public Transform objectToAttach; // Objet à attacher
    private bool isBeingHeld = false;
    public OVRHand ovrHand; // Référence au composant OVRHand

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
                // Relâche l'objet si le pincement est relâché
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

        // Vérifie si la main entre en contact avec l'objet
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
        transform.SetParent(objectToAttach); // Attacher directement à la main
        transform.localPosition = new Vector3(0, 0, 0.1f);
        transform.localRotation = Quaternion.Euler(90, 0, 0);
    }

    private void ReleaseObject()
    {

        isBeingHeld = false;
        transform.SetParent(null); // Relâcher l'objet
        Debug.Log("im launching the dart");

        GetComponent<DartLaunch>().FireDart();

    }

    private void FollowHand()
    {

        // Suivre la position de l'objet attaché avec un décalage
        transform.position = objectToAttach.position + offset;

        // Appliquer une rotation inversée
        transform.rotation = objectToAttach.rotation * Quaternion.Euler(rotOffsetAngles);
    }
}
