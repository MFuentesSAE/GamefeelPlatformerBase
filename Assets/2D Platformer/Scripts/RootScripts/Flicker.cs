using UnityEngine;
using DG.Tweening;

public class Flicker : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public GameObject stompCollider;
    public Color targetColor;
    public float tweenTime;
    public int loops;
    public Ease easeType;// variable de DOTween, forma de suavizado de interpolación
    public LoopType loopType; //variable de DOTween, indica de que forma se comporan los loops, yoyo es la ideal en la mayoría de los casos
    private Tween flickerTween;
    private const int PLAYER_LAYER = 3;
    private const int INUME_LAYER = 8;


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

        flickerTween = spriteRenderer.DOColor(targetColor, tweenTime).SetLoops(loops, loopType)
            .OnStart(Inmunity)
            .OnComplete(EndInmunity)
            .SetUpdate(true);
    }

    private void Inmunity()
    {
        gameObject.layer = INUME_LAYER;
        stompCollider?.SetActive(false);
	}

    private void EndInmunity()
    {
        gameObject.layer = PLAYER_LAYER;
		stompCollider?.SetActive(true);
	}
}
