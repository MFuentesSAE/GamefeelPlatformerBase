using UnityEngine;
using DG.Tweening;
using Platformer;

public class EnemyFader : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public EnemyAI enemyAI;
	public Color fadeColor;
    public float fadeTime;
    private const int INMUNE_LAYER = 8;
    private const string IDLE_TRIGGER = "Idle";

	void Start()
    {
        
    }

    public void Fade()
    {
        enemyAI.BlockMovement(true);
		rigidbody2D.linearVelocity = Vector2.zero;
		rigidbody2D.gravityScale = 1.75f;
		spriteRenderer.gameObject.layer = INMUNE_LAYER;
        animator?.SetTrigger(IDLE_TRIGGER);

		spriteRenderer.DOColor(fadeColor, fadeTime)
            .OnComplete(DisableEnemy);
	}

    void DisableEnemy()
    {
		spriteRenderer.gameObject.SetActive(false);

	}
}
