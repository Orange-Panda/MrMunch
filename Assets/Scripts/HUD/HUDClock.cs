using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDClock : MonoBehaviour
{
	public Image clockBack;
	public Image clockFill;
	public Image clockHand;

	private Timer timer;

    void Start()
    {
		InvokeRepeating("CheckForTimer", 0f, 1f);
    }

	private void CheckForTimer()
	{
		if (timer == null)
		{
			timer = FindObjectOfType<Timer>();
		}
	}

    void Update()
    {
		if (timer == null)
		{
			clockBack.enabled = false;
			clockFill.enabled = false;
			clockHand.enabled = false;
		}
		else
		{
			clockBack.enabled = true;
			clockFill.enabled = true;
			clockHand.enabled = true;
		}

		float progress = timer.TimeRemaining / timer.StartTime; //0-end 1-start
		clockHand.rectTransform.rotation = Quaternion.Euler(0, 0, -360 * progress);  //0-360
		clockFill.fillAmount = progress;
    }
}