using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for grabbing consumables and adding them to the mouth queue
/// </summary>
public class Hand : MonoBehaviour
{
	private MonsterMouth mouth;
	[SerializeField] private bool _useAnimationEvents = true;
	private List<Consumable> pickups = new List<Consumable>();

	private void Start()
	{
		mouth = GetComponentInParent<MonsterMouth>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Consumable"))
		{
			var consumable = other.GetComponent<Consumable>();
			if (consumable is null) return;

			pickups.Add(consumable);
			consumable.Collider.enabled = false;

			if (_useAnimationEvents)
			{
				other.transform.position = transform.position;
				other.transform.parent = transform;
			}
			else EatPickUps();
		}
	}

	public void EatPickUps()
	{
		for (int i = 0; i < pickups.Count; i++)
		{
			mouth.QueueForEating(pickups[i]);
		}

		if (pickups.Count > 0) pickups.Clear();
	}
}
