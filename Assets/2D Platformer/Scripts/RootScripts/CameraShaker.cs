using UnityEngine;
using Unity.Cinemachine;
using System.Collections;

public class CameraShaker : MonoBehaviour
{
    public int shakeAmplitude;
    public int shakeFrequency;
    public CinemachineBasicMultiChannelPerlin perlin;
    private Coroutine shakeRoutine;

    void Start()
    {
        //Asegurarse que no haya shake al incio;
        perlin.AmplitudeGain = 0;
        perlin.FrequencyGain = 0;
    }

    /// <summary>
    /// Vibración de cámara
    /// </summary>
    /// <param name="shakeTime">el tiempo que durará el Shake</param>
    public void ShakeCamera(float shakeTime)
    {
        perlin.AmplitudeGain = shakeAmplitude;
        perlin.FrequencyGain = shakeFrequency;

        if(shakeRoutine != null)
        {
            StopCoroutine(shakeRoutine);
        }

		shakeRoutine = StartCoroutine(StopShakeRoutine(shakeTime));
    }

    public void StopShake()
    {
		perlin.AmplitudeGain = 0;
		perlin.FrequencyGain = 0;
	}

    IEnumerator StopShakeRoutine(float shakeTime)
    {
        yield return new WaitForSeconds(shakeTime);
        StopShake();
	}

}
