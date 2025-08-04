using UnityEngine;
using UnityEngine.Events;

public class StompTrigger : MonoBehaviour
{
	public Rigidbody2D playerRigidbody;
	public UnityEvent onStompEvent;
	private const float BOUNCE_FORCE = 200;

	private void OnTriggerEnter2D(Collider2D other)
	{
		HpEnemy hp = other.GetComponent<HpEnemy>();

		if(hp != null)
		{
			hp.RemoveHp(1);

			if (playerRigidbody != null)
			{
				playerRigidbody.linearVelocity = Vector2.zero;
				playerRigidbody.AddForce(Vector2.up * BOUNCE_FORCE);
			}

			onStompEvent?.Invoke();
        }
	}
}
