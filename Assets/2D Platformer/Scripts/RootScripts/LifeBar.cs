using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
	public LayoutGroup anchor;
	public Image imageHeartPrefab;

	private Color normalColor = Color.white;
	private Color damageColor = Color.grey;

	private Vector2 imageSize = new Vector2(128, 128);
	private List<Image> lifeImageList = new List<Image>();


	public void UpdateLifeBar(int currentHp)
	{
		int clampedHp = Mathf.Clamp(currentHp, 0, lifeImageList.Count-1);

		for (int i = 0; i < lifeImageList.Count; i++)
		{
			lifeImageList[i].color = i < clampedHp ? normalColor : damageColor;
		}
	}

	public void CreateImages(int maxHp)
	{
		for (int i = 0; i < maxHp; i++)
		{
			Image image = Instantiate(imageHeartPrefab, anchor.transform);
			image.color = normalColor;
			lifeImageList.Add(image);
		}
	}
}
