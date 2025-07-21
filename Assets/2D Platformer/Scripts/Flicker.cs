using UnityEngine;
using DG.Tweening;

public class Flicker : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color targetColor;
    public float tweenTime;
    public int loops;
    public Ease easeType;// variable de DOTween, forma de suavizado de interpolación
    public LoopType loopType; //variable de DOTween, indica de que forma se comporan los loops, yoyo es la ideal en la mayoría de los casos
    private Tween flickerTween;


    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Flick();
        }
    }

    public void Flick()
    {
        if(flickerTween != null)
        {
            flickerTween.Kill(true);
        }
        //flickerTween?.Kill(true);

        flickerTween = spriteRenderer.DOColor(targetColor, tweenTime).SetLoops(loops, loopType);
    }
}
