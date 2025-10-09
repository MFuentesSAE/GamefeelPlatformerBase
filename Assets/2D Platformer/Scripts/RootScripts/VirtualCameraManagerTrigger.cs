using Unity.Cinemachine;
using UnityEngine;

public class VirtualCameraManagerTrigger : MonoBehaviour
{
    public VirtualCameraManager virtualCameraManager;
    public int cameraToSwitch;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            virtualCameraManager.SwitchCamera(cameraToSwitch);
        }
    }
}
