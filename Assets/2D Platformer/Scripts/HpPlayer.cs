using UnityEngine;
using UnityEngine.Events;

public class HpPlayer : HpBase
{
	[SerializeField, Space(10)]
	private UnityEvent<int> onStartEvent, onModifyHpEvent;

	protected override void Start()
	{
		base.Start();
		onStartEvent?.Invoke(maxHp);
	}

	public override void RemoveHp(int amount)
	{
		base.RemoveHp(amount);
		onModifyHpEvent?.Invoke(currentHp);
		if(currentHp <= 0)
		{
			gameManager?.GameOver();
		}
	}
}
