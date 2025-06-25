using Platformer;
using UnityEngine;

public class HpBase : MonoBehaviour
{
    public int maxHp;
    protected int currentHp;
    protected GameManager gameManager;

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
}
