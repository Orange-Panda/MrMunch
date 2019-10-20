using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDFullness : MonoBehaviour
{
	public Image icon;
	public Image barBG;
	public Image barFill;
	public bool inverted;

	private Monster monster;

    void Start()
    {
		InvokeRepeating("FindMonster", 0f, 1f);
    }

	private void FindMonster()
	{
		if (monster == null)
		{
			monster = FindObjectOfType<Monster>();
		}
	}

    void Update()
    {
		if (monster == null)
		{
			icon.enabled = false;
			barBG.enabled = false;
			barFill.enabled = false;
		}
		else
		{
			icon.enabled = true;
			barBG.enabled = true;
			barFill.enabled = true;
		}

		barFill.fillAmount = inverted ? Mathf.Abs(monster.PercentageFull - 1) : monster.PercentageFull;
	}
}
