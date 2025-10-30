using Platformer;
using UnityEngine;
using UnityEngine.Events;

public class HpPlayer : HpBase
{
	[SerializeField, Space(10)]
	private UnityEvent<int> onStartEvent, onModifyHpEvent;
	public PlayerController playerController;

	[SerializeField, Space(10)]
	private UnityEvent onDieEvent;

	protected override void Start()
	{
		base.Start();
		onStartEvent?.Invoke(maxHp);
	}

	public override void RemoveHp(int amount)
	{
		base.RemoveHp(amount);
		onModifyHpEvent?.Invoke(currentHp);
		CameraManager.instance?.ShakeCamera();
		if(currentHp <= 0)
		{
			playerController?.Death();
			gameManager?.GameOver();
			onDieEvent?.Invoke();
		}
	}
}
