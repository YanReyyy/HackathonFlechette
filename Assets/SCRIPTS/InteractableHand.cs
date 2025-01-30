using UnityEngine;
using Debug = UnityEngine.Debug;

public class InteractableObject : MonoBehaviour
{
    public Transform objectToAttach; // Objet à attacher
    private bool isBeingHeld = false;
    public OVRHand ovrHand; // Référence au composant OVRHand

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
        transform.localPosition = Vector3.zero; // Ajuster la position relative
        transform.localRotation = Quaternion.identity; // Ajuster la rotation relative
    }

    private void ReleaseObject()
    {
        isBeingHeld = false;
        transform.SetParent(null); // Relâcher l'objet
    }

    private void FollowHand()
    {
        // Suivre la position et la rotation de l'objet attaché
        transform.position = objectToAttach.position;
        transform.rotation = objectToAttach.rotation;
    }
}
