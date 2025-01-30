using UnityEngine;

public class PinchDetection : MonoBehaviour
{
    public OVRHand ovrHand; // R�f�rence au composant OVRHand

    void Update()
    {
        if (ovrHand != null && ovrHand.IsTracked)
        {
            // V�rifiez si l'index pinche
            if (ovrHand.GetFingerIsPinching(OVRHand.HandFinger.Index))
            {
                // Code � ex�cuter quand l'index pinche
                OnPinchStart();
            }
            else
            {
                // Code � ex�cuter quand l'index ne pinche plus
                OnPinchEnd();
            }
        }
    }

    private void OnPinchStart()
    {
        UnityEngine.Debug.Log("Pinch Started"); // Utilise explicitement UnityEngine.Debug
        // Actions � r�aliser au d�but du pinch
    }

    private void OnPinchEnd()
    {
        UnityEngine.Debug.Log("Pinch Ended"); // Utilise explicitement UnityEngine.Debug
        // Actions � r�aliser � la fin du pinch
    }
}
