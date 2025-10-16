using Platformer;
using UnityEngine;

public class StompTrigger : MonoBehaviour
{
	[Range(1, 20)]
	public float bounceForce;
	public Rigidbody2D rigidbody;
	public Collider2D trigger;
	public PlayerController playerController;

    void Start()
    {
		trigger.isTrigger = true;

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(playerController == null || playerController.isGrounded)
		{
			return;
		}

		HpEnemy hp = collision.GetComponent<HpEnemy>();

		if(hp == null)
		{
			return;
		}

		hp.RemoveHp(hp.maxHp);

		if(rigidbody == null)
		{
			return;
		}

		rigidbody.linearVelocity = Vector2.zero;
		rigidbody.AddForce(new Vector2(0, bounceForce), ForceMode2D.Impulse);
	}
}
