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
		hp.RemoveHp(hp.maxHp);
	}
}
