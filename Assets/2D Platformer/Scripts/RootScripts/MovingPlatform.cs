using UnityEngine;
using DG.Tweening;

public class MovingPlatform : MonoBehaviour
{
    public Transform platfrom;
    public Transform destination;
    public float tweenTime;
    public Ease tweenEase;
    private Tween platformTween;
    
    void Start()
    {
        //SetLoops(-1); si el valor es -1 los loops son infinitos
        platformTween = platfrom.DOMove(destination.position, tweenTime).SetLoops(-1, LoopType.Yoyo).SetEase(tweenEase);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            platformTween.Pause();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            platformTween.Play();
        }
    }
}
