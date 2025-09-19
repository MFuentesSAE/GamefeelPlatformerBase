using Platformer;
using UnityEngine;
using UnityEngine.Events;

public class HpBase : MonoBehaviour
{
    public int maxHp;
    protected int currentHp;
    protected GameManager gameManager;
    public UnityEvent onDeathEvent;

    protected virtual void Start()
    {
        currentHp = maxHp;
        gameManager = GameManager.instance;
	}

    public virtual void RemoveHp(int amount)
    {
        currentHp -= amount;
        currentHp = Mathf.Clamp(currentHp, 0, maxHp);
    }

    public bool IsAlive()
    {
        return currentHp > 0;   
    }
}
