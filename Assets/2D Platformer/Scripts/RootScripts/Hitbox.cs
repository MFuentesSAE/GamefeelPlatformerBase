using UnityEngine;

public class Hitbox : MonoBehaviour
{
	private Collider2D hitbox;
	private void Start()
	{
		hitbox = transform.GetComponent<Collider2D>();
		hitbox.enabled = false;	
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		HpEnemy hp = collision.GetComponent<HpEnemy>();

		if(hp != null)
		{
			TimeManager.instance.FreezeFrame(0, 0.05f);
		}

		hp?.RemoveHp(hp.maxHp);
	}
}
