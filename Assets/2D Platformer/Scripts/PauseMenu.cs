using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PauseMenu : MonoBehaviour
{
    public KeyCode pauseKey;
    public CanvasGroup canvasGroup;

    private bool gamePaused;
    private const float TWEEN_TIME = 0.3f;
    private Tween pauseTween;
    
    void Start()
    {
        gamePaused = false;
        canvasGroup.alpha = 0;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            TogglePause(!gamePaused);
        }
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
}
