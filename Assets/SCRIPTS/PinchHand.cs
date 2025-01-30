using UnityEngine;

public class PinchDetection : MonoBehaviour
{
    public OVRHand ovrHand; // Référence au composant OVRHand

    void Update()
    {
        if (ovrHand != null && ovrHand.IsTracked)
        {
            // Vérifiez si l'index pinche
            if (ovrHand.GetFingerIsPinching(OVRHand.HandFinger.Index))
            {
                // Code à exécuter quand l'index pinche
                OnPinchStart();
            }
            else
            {
                // Code à exécuter quand l'index ne pinche plus
                OnPinchEnd();
            }
        }
    }

    private void OnPinchStart()
    {
        UnityEngine.Debug.Log("Pinch Started"); // Utilise explicitement UnityEngine.Debug
        // Actions à réaliser au début du pinch
    }

    private void OnPinchEnd()
    {
        UnityEngine.Debug.Log("Pinch Ended"); // Utilise explicitement UnityEngine.Debug
        // Actions à réaliser à la fin du pinch
    }
}
