using UnityEngine;
using UnityEngine.UI;
using DG.Tweening; //Importar tweens
using UnityEngine.Events; //Importar eventos

public class UiFader : MonoBehaviour
{
    public Image fadeImage;
    public UnityEvent onCompleteTweenEvent;
    public float fadeTime = 1;
    private const float DELAY_TIME = 1;

    void Start()
    {
        fadeImage.raycastTarget = false;// hacer la imagen no interactiva

        //Seteamos que la imagen siempre inicie en negro para después bajas su transparencia
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1);
        fadeImage.DOFade(0, fadeTime).SetDelay(DELAY_TIME);
    }

    public void FadeToBlack()
    {
        fadeImage.DOFade(1, fadeTime).OnComplete(onCompleteTweenEvent.Invoke);
    }

    

}
