using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// Handles stuff necessary to "eat", and later on mouth animation
/// </summary>
public class MonsterMouth : MonoBehaviour
{
    private Monster _monster;
    private MonsterAudio _audio;

	[Range(0.1f, 2f)]
	[SerializeField] private float eatDelay = 0.5f;
    [SerializeField] private MunchFX _munchFX;
    [SerializeField] private Transform _mouthOrigin;

    private Queue<Consumable> foodQueue = new Queue<Consumable>();

    private void Start()
    {
        _monster = GetComponent<Monster>();
        _audio = GetComponent<MonsterAudio>();

        Assert.IsNotNull(_monster);
        Assert.IsNotNull(_audio);
        Assert.IsNotNull(_munchFX);

		StartCoroutine(Eat());
    }

	/// <summary>
	/// Processes food at the frequency of eatDelay.
	/// </summary>
	private IEnumerator Eat()
	{
		while (gameObject.activeSelf)
		{
			if (foodQueue.Count > 0)
			{
				ProcessConsumable(foodQueue.Dequeue());
			}

			yield return new WaitForSeconds(eatDelay);
		}
	}

	/// <summary>
	/// Adds a consumable to the queue of objects to eat.
	/// </summary>
	/// <param name="consumable">The consumable to queue.</param>
    public void QueueForEating(Consumable consumable)
    {
        consumable.transform.position = _mouthOrigin.position;
        consumable.transform.parent = _mouthOrigin;
        foodQueue.Enqueue(consumable);
    }

	/// <summary>
	/// Processes the consumable by playing feedback, then destroying it.
	/// </summary>
	/// <param name="consumable">The consumable to process</param>
    public void ProcessConsumable(Consumable consumable)
    {
        _monster.Fullness += consumable.FillAmount;
        _audio.PlayMunchSound(consumable.Type);
        _munchFX.PlayMunchParticles(consumable.Type);
        Destroy(consumable.gameObject);
    }
}
