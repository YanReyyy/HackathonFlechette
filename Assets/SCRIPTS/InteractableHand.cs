using UnityEngine;
using Debug = UnityEngine.Debug;

public class InteractableObject : MonoBehaviour
{
    public Transform objectToAttach; // Objet � attacher
    private bool isBeingHeld = false;
    public OVRHand ovrHand; // R�f�rence au composant OVRHand

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
        transform.localPosition = Vector3.zero; // Ajuster la position relative
        transform.localRotation = Quaternion.identity; // Ajuster la rotation relative
    }

    private void ReleaseObject()
    {
        isBeingHeld = false;
        transform.SetParent(null); // Rel�cher l'objet
    }

    private void FollowHand()
    {
        // Suivre la position et la rotation de l'objet attach�
        transform.position = objectToAttach.position;
        transform.rotation = objectToAttach.rotation;
    }
}
