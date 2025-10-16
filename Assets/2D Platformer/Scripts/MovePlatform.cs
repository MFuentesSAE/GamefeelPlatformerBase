using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class MovePlatform : MonoBehaviour
{
    public Transform targetPlatform, destination;
    public float tweenTime;
    public LoopType loopType;
    public Ease ease;
    private Tween platfromTween;

    void Start()
    {
        platfromTween = targetPlatform.DOMove(destination.position, tweenTime).SetLoops(-1, loopType).SetEase(ease);
    }

    private void OnCollisionEnter2D(Collision2D collison)
    {
        if(collison.gameObject.CompareTag("Player"))
        {
            platfromTween.Pause();
        }
    }

    private void OnCollisionExit2D(Collision2D collison)
    {
        if(collison.gameObject.CompareTag("Player"))
        {
            platfromTween.Play();
        }
    }

}
