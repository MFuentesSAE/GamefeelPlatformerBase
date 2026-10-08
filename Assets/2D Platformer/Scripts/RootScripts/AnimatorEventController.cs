using Platformer;
using UnityEngine;

public class AnimatorEventController : MonoBehaviour
{
    public Collider2D hitbox;
    public PlayerController playerController;

	private void Start()
	{
		hitbox.isTrigger = true;
	}

	public void StopMovement()
	{
		playerController.BlockInput(true);
	}

	public void ResumeMovement()
	{
		playerController.BlockInput(false);
	}

	public void EnableHitbox()
    {
        hitbox.enabled = true;
	}

    public void DisableHitbox()
    {
		hitbox.enabled = false;
	}
}
