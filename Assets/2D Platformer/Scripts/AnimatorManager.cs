using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public Animator animator;

	void Start()
    {
        
    }

    public virtual void SetTrigger(string triggerName)
    {
		animator?.SetTrigger(triggerName);
	}

	public virtual void SetBool(string boolName, bool value)
	{
		animator?.SetBool(boolName, value);
	}

	public virtual void SetFloat(string floatName, float value)
    {
		animator?.SetFloat(floatName, value);
	}

	public virtual void SetInt(string intName, int value)
	{
		animator?.SetFloat(intName, value);
	}
}
