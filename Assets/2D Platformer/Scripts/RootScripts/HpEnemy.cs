using UnityEngine;
using UnityEngine.Events;

public class HpEnemy : HpBase
{
	public UnityEvent onDieEvent;

	public override void RemoveHp(int amount)
	{
		base.RemoveHp(amount);
		if(currentHp <= 0)
		{
			onDieEvent?.Invoke();
		}
	}
}
