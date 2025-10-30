using UnityEngine;

public class CameraSwitchTrigger : MonoBehaviour
{
    public int cameraSwitchEnter, cameraSwitchExit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CameraManager.instance?.CameraSwitch(cameraSwitchEnter);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CameraManager.instance?.CameraSwitch(cameraSwitchExit);
        }
    }
}
