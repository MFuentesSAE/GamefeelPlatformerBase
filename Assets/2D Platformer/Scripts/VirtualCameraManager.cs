using UnityEngine;
using Unity.Cinemachine;
using System.Collections;// importar cinemachine

public class VirtualCameraManager : MonoBehaviour
{
    public CinemachineCamera[] virtualCameraList;
    public int startCameraId;

    public bool transitionOnStart;
    public int defaultStartCameraTransition;
    public const float DEFAULT_TRANSITION_TIME = 2;

    void Start()
    {
        //Asinganar el Id a las cámaras de forma progresiva
        for(int i = 0; i < virtualCameraList.Length; i++)
        {
            virtualCameraList[i].Priority = i;
        }

        //Cambiar a la cámara default al inicio
        SwitchCamera(startCameraId);

        if (transitionOnStart)
        {
            StartCoroutine(SwitchCameraDelay(defaultStartCameraTransition));
        }
    }


    public void SwitchCamera(int cameraId)
    {
        //Asegurarse de que no se evalúe un id que no existe limitándolo a valores dentro de la longitud del la lista
        int clampedIndex = Mathf.Clamp(cameraId, 0, virtualCameraList.Length-1);


        //buscar cámara por el id pasado, solo dejar esa prendida y apagar las demás
        for (int i = 0; i < virtualCameraList.Length; i++)
        {
            if (virtualCameraList[i].Priority == clampedIndex)
            {
                virtualCameraList[i].gameObject.SetActive(true);
            }
            else
            {
                virtualCameraList[i].gameObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Corutina para cambiar de cámara después de esperar ciertos segundos
    /// </summary>
    /// <param name="cameraId">el id de la cámara a cambiar</param>
    IEnumerator SwitchCameraDelay(int cameraId)
    {
        yield return new WaitForSeconds(DEFAULT_TRANSITION_TIME);
        SwitchCamera(cameraId);
    }

}
