using UnityEngine;

public class HpEnemy : HpBase
{
	public override void RemoveHp(int amount)
	{
		base.RemoveHp(amount);
		if(currentHp <= 0)
		{
			gameObject.SetActive(false);
		}
	}
}
