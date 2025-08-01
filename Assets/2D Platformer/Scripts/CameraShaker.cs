using UnityEngine;
using Unity.Cinemachine;
using System.Collections;

public class CameraShaker : MonoBehaviour
{
    public int shakeAmplitude;
    public int shakeFrequency;
    public CinemachineBasicMultiChannelPerlin perlin;


    void Start()
    {
        //Asegurarse que no haya shake al incio;
        perlin.AmplitudeGain = 0;
        perlin.FrequencyGain = 0;
    }

    /// <summary>
    /// Vibraci�n de c�mara
    /// </summary>
    /// <param name="shakeTime">el tiempo que durar� el Shake</param>
    public void ShakeCamera(float shakeTime)
    {
        perlin.AmplitudeGain = shakeAmplitude;
        perlin.FrequencyGain = shakeFrequency;
        StartCoroutine(StopShakeRoutine(shakeTime));
    }

    IEnumerator StopShakeRoutine(float shakeTime)
    {
        yield return new WaitForSeconds(shakeTime);
        perlin.AmplitudeGain = 0;
        perlin.FrequencyGain = 0;
    }

}
