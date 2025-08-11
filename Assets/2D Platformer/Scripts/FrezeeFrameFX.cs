using System.Collections;
using UnityEngine;

public class FrezeeFrameFX : MonoBehaviour
{
    public float frezeeFrameDuration;
    public float freezeTimeValue;
    private Coroutine freezeFrameRoutine;

	private void OnDisable()
	{
        StopFreezeCouroutine();
		Time.timeScale = 1;
	}

	public void FreezeFrame()
    {
        StopFreezeCouroutine();
		freezeFrameRoutine = StartCoroutine(FreezeFrameRoutine());
    }

    private void StopFreezeCouroutine()
    {
		if (freezeFrameRoutine != null)
		{
			StopCoroutine(freezeFrameRoutine);
		}
	}

    IEnumerator FreezeFrameRoutine()
    {
        Time.timeScale = freezeTimeValue;
        yield return new WaitForSecondsRealtime(frezeeFrameDuration);
        Time.timeScale = 1;
    }
}
