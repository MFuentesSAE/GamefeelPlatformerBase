using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public KeyCode pauseKey;
    public CanvasGroup canvasGroup;

    private bool gamePaused;
    private const float TWEEN_TIME = 0.3f;
    private Tween pauseTween;
    public SoundManager uiSoundManager;

    public AudioMixerGroup audioMixerGroupMaster, audioMixerGroupMusic, audioMixerGroupSFX;
    
    void Start()
    {
        gamePaused = false;
        canvasGroup.alpha = 0;
        uiSoundManager?.FadeInSound("MainTheme", 4);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            TogglePause(!gamePaused);
            if (gamePaused)
            {
                uiSoundManager?.FadeOutSound("MainTheme", 1);
            }
            else
            {
                uiSoundManager?.FadeInSound("MainTheme", 1);
            }
        }
#if UNITY_EDITOR

#endif
    }

    public void TogglePause(bool paused)
    {
        Time.timeScale = paused ? 0 : 1;

        //if(paused)
        //{
        //    Time.timeScale = 0;
        //}
        //else
        //{
        //    Time.timeScale = 1;
        //}

        float canvasAlpha = paused ? 1 : 0;

        //if(pauseTween != null)
        //{
        //    pauseTween.Kill();
        //}

        pauseTween?.Kill();

        //SetUpdate(true), significa que el tween va a correr en realtime y no runtime, independiente del timescale de Unity.
        pauseTween = canvasGroup.DOFade(canvasAlpha, TWEEN_TIME).SetUpdate(true);
        gamePaused = paused;
    }

    public void SetMasterVolume(float volume)
    {
        audioMixerGroupMaster.audioMixer.SetFloat("VolumeMaster", volume);
    }

    public void SetMasterMusic(float volume)
    {
        audioMixerGroupMusic.audioMixer.SetFloat("VolumeMusic", volume);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixerGroupSFX.audioMixer.SetFloat("VolumeSFX", volume);
    }

}
