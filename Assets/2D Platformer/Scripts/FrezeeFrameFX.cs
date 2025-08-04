using System.Collections;
using UnityEngine;

public class FrezeeFrameFX : MonoBehaviour
{
    public float frezeeFrameDuration;
    public float freezeTimeValue;
    private Coroutine freezeFrameRoutine;

    public void FreezeFrame()
    {
        if(freezeFrameRoutine != null)
        {
            StopCoroutine(freezeFrameRoutine);
        }

        freezeFrameRoutine = StartCoroutine(FreezeFrameRoutine());
    }

    IEnumerator FreezeFrameRoutine()
    {
        Time.timeScale = freezeTimeValue;
        yield return new WaitForSecondsRealtime(frezeeFrameDuration);
        Time.timeScale = 1;
    }
}
